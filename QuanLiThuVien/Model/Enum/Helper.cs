using System;
using System.ComponentModel;
using System.Reflection;

namespace QuanLiThuVien.Model.Enum
{
    internal static class Helper
    {
        public static string GetEnumDescription(System.Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute =
                (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }

        // Lấy list enum + description để bind cho ComboBox
        public static List<KeyValuePair<T, string>> GetEnumList<T>() where T : System.Enum
        {
            return System.Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .Select(v => new KeyValuePair<T, string>(v, GetEnumDescription(v)))
                       .ToList();
        }
    }
}
