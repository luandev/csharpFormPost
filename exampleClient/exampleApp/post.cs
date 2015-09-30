using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace testPutDataWebservice
{
    public class post
    {

        public post()
        {

        }

        /// <summary>
        /// Assincronouslly send the fields in the list to webServer in url parameter
        /// NextStep: add a percentage of uploaded data!
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        internal static async Task<string> send(List<field> fields, string url)
        {
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            foreach(field f in fields)
            {
                if(f.kind == fieldKind.text)
                {
                    form.Add(new StringContent(f.content), f.name);
                }
                else if (f.kind == fieldKind.file)
                {
                    HttpContent content = new ByteArrayContent(f.bytes);
                    content.Headers.Add("Content-Type", f.contentType);
                    form.Add(content, f.name, f.fileName);
                }
            }

            HttpResponseMessage response = await httpClient.PostAsync(url, form);

            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            return response.Content.ReadAsStringAsync().Result;
        }

       
    }
}