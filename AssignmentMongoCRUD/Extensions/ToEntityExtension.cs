using System.Reflection;

namespace AssignmentMongoCRUD.Extensions
{
    public static class ToEntityExtension
    {
        public static T2 ModelViewToEntity<T1, T2>(this T1 model)
        {
            T2 entity = (T2)Activator.CreateInstance(typeof(T2));

            PropertyInfo[] properties = typeof(T2).GetProperties();

            foreach (var property in properties)
            {

                property.SetValue(entity, typeof(T1).GetProperty(property.Name).GetValue(model));
            }
            return entity;
        }
    }
}
