namespace LegalCaseManagementSystem.Model
{
    public static class ProfileDisplay
    {
        public const string Missing = "";

        public static string Text(string? value) =>
            string.IsNullOrWhiteSpace(value) ? Missing : value.Trim();

        public static string Date(DateTime? value) =>
            value.HasValue ? value.Value.ToString("dd MMM yyyy") : Missing;
    }
}