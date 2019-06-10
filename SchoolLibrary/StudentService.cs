using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary0
{
    public class Student0Service
    {
        string baseUrl = "https://localhost:44318/";


        public async Task<Student[]> GetStudentsAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/students");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Student[]>(json);
        }

        public async Task<Student> GetStudentsByIdAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/students/{id}");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(json);
        }

        public async Task<Student> InsertStudentAsync(Student student)
        {
            var client = new HttpClient();
            var response = await client.PostAsync($"{baseUrl}api/students", student, new JsonMediaTypeFormatter());
            return await response.Content.ReadAsAsync<Student>();
        }

        public async Task<Student> UpdateStudentAsync(string id, Student student)
        {
            var client = new HttpClient();
            var response = await client.PutAsync($"{baseUrl}api/students/{id}", student, new JsonMediaTypeFormatter());
            return await response.Content.ReadAsAsync<Student>();
        }

        public async Task<HttpResponseMessage> DeleteStudentAsync(string id)
        {
            var client = new HttpClient();
            return await client.DeleteAsync($"{baseUrl}api/students/{id}");
        }

    }
}
