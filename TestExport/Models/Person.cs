namespace TestExport.Models
{
    public class Person
    {
        [CsvHelper.Configuration.Attributes.Name("id")]
        public int Id { get; set; }

        [CsvHelper.Configuration.Attributes.Name("ファーストネーム")]
        public string FirstName { get; set; }

        [CsvHelper.Configuration.Attributes.Name("苗字")]
        public string LastName { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Eメール")]
        public string Email { get; set; }
    }
}
