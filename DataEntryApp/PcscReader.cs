using GS.Apdu;
using GS.PCSC;
using GS.SCard;
using GS.Util.Hex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryApp
{
    public static class PcscReader
    {
        public delegate void OnCardScanned(string uid);
        public delegate void OnError(string message);

        public static event OnCardScanned CardScanned;
        public static event OnError Error;

        public static void Initialize()
        {
            Task.Run(async () =>
            {
                await Read();
            });
        }

        public static void InvokeScanned(string uid)
        {
            CardScanned?.Invoke(uid);
        }

        private static void InvokeError(string message)
        {
            Error?.Invoke(message);
        }

        public static async Task Read()
        {
            PCSCReader reader = new PCSCReader();

            while (true)
            {
                try
                {
                    reader.Connect();
                    reader.ActivateCard();

                    RespApdu respApdu = reader.Exchange("FF CA 00 00 00"); // Get Card UID ...

                    if (respApdu.SW1SW2 == 0x9000)
                    {
                       InvokeScanned("0x" + HexFormatting.ToHexString(respApdu.Data, false));
                       await Task.Delay(1000);
                    }
                }

                catch (WinSCardException ex)
                {
                    InvokeError(ex.WinSCardFunctionName + " Error 0x" + ex.Status.ToString("X08") + ": " + ex.Message);
                    await Task.Delay(1000);
                }

                catch (Exception ex)
                {
                    InvokeError(ex.Message);
                    await Task.Delay(1000);
                }

                finally
                {
                    reader.Disconnect();
                }
            }
        }
    }
}
