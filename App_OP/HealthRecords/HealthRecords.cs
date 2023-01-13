using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CIS.Core;
using CIS.Utility;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace App_OP.HealthRecords
{
    public class HealthRecordsURLHelper
    {
        public void Handler()
        {
            if (SysContext.GetCurrPatient == null)
                return;

            var url = this.GetURL(SysContext.GetCurrPatient.IDCard);
            if (!string.IsNullOrEmpty(url))
                Process.Start(url);
        }

        private string GetURL(string idcard)
        {
            var baseUrl = SysContext.CurrUser.Params.OP_HealthRecords_Url;
            var encryptionUrl = SysContext.CurrUser.Params.OP_HealthRecords_Encryption_Url;
            var key = SysContext.CurrUser.Params.OP_HealthRecords_AESKey;
            var account = SysContext.CurrUser.Params.OP_HealthRecords_Account;
            var password = SysContext.CurrUser.Params.OP_HealthRecords_Password;

            HTTPHelper.HttpPost(encryptionUrl, $"{{\"publicVal\":\"{key}\"}}", HTTPHelper.ContentType.Json, out var response);
            var result = SerializeHelper.BeginJsonDeserialize<EncryptionResponse>(response);
            var iv = result?.data?.ivParameter;
            if (iv == null)
            {
                System.Windows.Forms.MessageBox.Show("获取秘钥失败");
                return "";
            }

            password = this.CryptAES(password + "&&" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), key, iv);
            account = this.CryptAES(account, key, iv);
            idcard = this.CryptAES(idcard, key, iv);

            password = Uri.EscapeDataString(password);
            account = Uri.EscapeDataString(account);
            idcard = Uri.EscapeDataString(idcard);

            var baseParame = $"/#/?idCard={idcard}&systemCode=12321181468778299Y&systemName=丹阳市中医院HIS&organCode=12321181468778299Y&organName=丹阳市中医院&doctorCode={SysContext.CurrUser.UserId}&doctorName={SysContext.CurrUser.UserName}&isEncrypted=1&hideSearchBtn=1&account={account}&password={password}";

            return baseUrl + baseParame;
        }

        private string CryptAES(string txt, string key, string iv)
        {
            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                byte[] lvBytes = Encoding.UTF8.GetBytes(iv);
                byte[] dataBytes = Encoding.UTF8.GetBytes(txt);
                IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CTR/NoPadding");
                cipher.Reset();
                int blockSize = cipher.GetBlockSize();
                int plaintextLength = dataBytes.Length;
                if (plaintextLength % blockSize != 0)
                {
                    plaintextLength = plaintextLength + (blockSize - (plaintextLength % blockSize));
                }
                else
                {
                    plaintextLength = plaintextLength + blockSize;
                }
                byte[] plaintext = new byte[plaintextLength];
                System.Array.Copy(dataBytes, 0, plaintext, 0, dataBytes.Length);

                cipher.Init(true, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("AES", keyBytes), lvBytes));
                byte[] inArray = cipher.DoFinal(plaintext);
                return Convert.ToBase64String(inArray, 0, inArray.Length);
            }
            catch
            {
                return "";
            }
        }
    }
}

