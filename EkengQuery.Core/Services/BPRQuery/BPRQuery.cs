using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace EkengQuery.Core
{
    public class BPRQuery : IBPRQuery
    {
        protected readonly IHttpClientFactory _clientFactory;

        public BPRQuery(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }



        public async Task<PassportWebServiceResponse> GetCitizenByPassport(string passportNumber)
        {
            PassportWebServiceResponse citizen = new PassportWebServiceResponse();

            var queryString = new Dictionary<string, string>()
                {
                    { "token", "c80f94cc-083c-3383-8282-bf77e1c3de35" },
                    { "type", "doc_nam" },
                    { "opaque", "3" },
                    { "documentNumber", passportNumber}
                };
            var requestUri = QueryHelpers.AddQueryString("https://ssn-api.ekeng.am/get-user", queryString);
            
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            var content = JsonConvert.DeserializeObject<WebServiceResponse>(await response.Content.ReadAsStringAsync());

                      

            if (response.IsSuccessStatusCode)
            {
                
                var decriptedData = this.DecriptData(content.Data);
                var replacedDecriptedData = decriptedData.Replace('[', '{').Replace(']', '}');
                PassportDataResponse decriptedDataDeserialize = JsonConvert.DeserializeObject<PassportDataResponse>(replacedDecriptedData);
                if (content.Status == "OK")
                {
                citizen.AVVRegistrationAddress = decriptedDataDeserialize.Data.AVVRegistrationAddress;
                citizen.Full_name = decriptedDataDeserialize.Data.Full_name;
                citizen.PNum = decriptedDataDeserialize.Data.PNum;
                citizen.Status = content.Status;
                }
            }

            return citizen;
        }


        public string DecriptData(string value)
        {
            string strIV = "O9fGelU066lJf7tiIjTw7w==";
            string strKey = "4c47c5ac232d39baa8d18b7ba9804694";

            string decriptedData = Decod(value, strKey, strIV);

            return decriptedData;
        }


        public static string Decod(string TextToDecrypt, string strKey, string strIV)
        {
            byte[] EncryptedBytes = Convert.FromBase64String(TextToDecrypt);


            byte[] dataIV = System.Convert.FromBase64String(strIV);


            //Setup the AES provider for decrypting.            
            AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();

            aesProvider.BlockSize = 128;
            aesProvider.KeySize = 256;
            //My key and iv that i have used in openssl
            aesProvider.Key = System.Text.Encoding.ASCII.GetBytes(strKey);
            //aesProvider.IV = System.Text.Encoding.UTF8.GetBytes(strIV);
            aesProvider.Padding = PaddingMode.PKCS7;
            aesProvider.Mode = CipherMode.CBC;


            ICryptoTransform cryptoTransform = aesProvider.CreateDecryptor(aesProvider.Key, dataIV);
            byte[] DecryptedBytes = cryptoTransform.TransformFinalBlock(EncryptedBytes, 0, EncryptedBytes.Length);
            return System.Text.Encoding.ASCII.GetString(DecryptedBytes);
        }

        public async Task<SSNWebServiceResponse> GetCitizenBySSN(string ssn)
        {
            SSNWebServiceResponse ssnWebServiceResponse = new SSNWebServiceResponse();

            var queryString = new Dictionary<string, string>()
                {
                    { "token", "c80f94cc-083c-3383-8282-bf77e1c3de35" },
                    { "opaque", "3" },
                    { "ssn", ssn}
                };

            var requestUri = QueryHelpers.AddQueryString("https://ssn-api.ekeng.am/authorize", queryString);
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var content = JsonConvert.DeserializeObject<WebServiceResponse>(await response.Content.ReadAsStringAsync());

            if (response.IsSuccessStatusCode)
            {
                if (content.Status == "OK")
                {
                    //var decriptedData = this.DecriptData("HjB2CEbIti1CX+F1B/Ar90mkBd+cCZoKSxsqg4saZhU=");
                    ssnWebServiceResponse.Status = content.Status;
                    var decriptedData = this.DecriptData(content.Data);
                    if (Regex.Matches(decriptedData, "DocumentIdentifier").Count > 1)
                    {
                        SSNDataResponseDocArray decriptedDataDeserialize = JsonConvert.DeserializeObject<SSNDataResponseDocArray>(decriptedData);
                        var docs = decriptedDataDeserialize.Passport_data.AVVDocuments.AVVDocument;
                        foreach (var doc in docs)
                        {
                            if (doc.FirstName != null)
                            {
                                ssnWebServiceResponse.FirstName = doc.FirstName;
                            }
                            if (doc.LastName != null)
                            {
                                ssnWebServiceResponse.LastName = doc.LastName;
                            }
                            if (doc.MiddleName != null)
                            {
                                ssnWebServiceResponse.MiddleName = doc.MiddleName;
                            }
                            if (doc.Gender != null)
                            {
                                ssnWebServiceResponse.Gender = doc.Gender;
                            }
                            if (doc.BirthDate != null)
                            {
                                if (doc.BirthDate.Contains("00/"))
                                {
                                    var replacedBirthDate = doc.BirthDate.Replace("00/", "01/");
                                    ssnWebServiceResponse.BirthDate = replacedBirthDate;
                                }
                                else
                                {
                                    ssnWebServiceResponse.BirthDate = doc.BirthDate;
                                }
                            }

                        }
                        ssnWebServiceResponse.Photo = decriptedDataDeserialize.Passport_data.Photo;
                    }
                    else
                    {
                        SSNDataResponse decriptedDataDeserialize = JsonConvert.DeserializeObject<SSNDataResponse>(decriptedData);
                        if (decriptedDataDeserialize.Passport_data.AVVDocuments.AVVDocument.BirthDate.Contains("00/"))
                        {
                            var replacedBirthDate = decriptedDataDeserialize.Passport_data.AVVDocuments.AVVDocument.BirthDate.Replace("00/", "01/");
                            ssnWebServiceResponse.BirthDate = replacedBirthDate;
                            ssnWebServiceResponse.Photo = decriptedDataDeserialize.Passport_data.Photo;
                        }
                        else
                        {
                            ssnWebServiceResponse.BirthDate = decriptedDataDeserialize.Passport_data.AVVDocuments.AVVDocument.BirthDate;
                            ssnWebServiceResponse.Photo = decriptedDataDeserialize.Passport_data.Photo;
                        }
                        ssnWebServiceResponse.FirstName = decriptedDataDeserialize.Passport_data.AVVDocuments.AVVDocument.FirstName;
                        ssnWebServiceResponse.LastName = decriptedDataDeserialize.Passport_data.AVVDocuments.AVVDocument.LastName;
                        ssnWebServiceResponse.MiddleName = decriptedDataDeserialize.Passport_data.AVVDocuments.AVVDocument.MiddleName;
                        ssnWebServiceResponse.Gender = decriptedDataDeserialize.Passport_data.AVVDocuments.AVVDocument.Gender;
                        ssnWebServiceResponse.Photo = decriptedDataDeserialize.Passport_data.Photo;
                    }
                    return ssnWebServiceResponse;
                }
                else
                {
                    //ssnWebServiceResponse.Status = CommonMessages.msgUnknownStatus;
                    //ssnWebServiceResponse.ErrorMessage = CommonMessages.msgUnknown;

                    return ssnWebServiceResponse;
                }
            }
            else
            {
                ssnWebServiceResponse.ErrorMessage = response.StatusCode + ": " + content.Message;
                return ssnWebServiceResponse;
            }
        }
    }
}
