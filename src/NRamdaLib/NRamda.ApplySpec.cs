using System;
using System.Collections.Generic;
using System.Linq;

namespace NRamdaLib
{
    public static partial class NRamda
    {
        /// <summary>
        /// Given a spec object recursively mapping properties to functions, creates a function 
        /// producing an object of the same structure, by mapping each property to the result 
        /// of calling its associated function with the supplied arguments.
        /// </summary>
        /// <typeparam name="T1">The input type of the functions.</typeparam>
        /// <typeparam name="T2">The return type of the functions.</typeparam>
        /// <param name="spec">The spec object.</param>
        /// <param name="collection">The collection to which the spec will be applied.</param>
        /// <remarks>This is almost completely pointless in C#. 
        /// Oh well! Got to try some pattern matching.</remarks>
        public static IDictionary<string, object> ApplySpec<T1, T2>(
            this IDictionary<string, object> spec,
            IEnumerable<T1> collection)
        {
            var list = collection.ToList();
            if (list.Count != 2)
            {
                throw new InvalidOperationException($"{nameof(collection)} count must be 2");
            }

            return ApplySpec<T1, T2>(spec, list, new Dictionary<string, object>());
        }

        /// <summary>
        /// Takes a spec object and returns a function which takes a collection of function arguments
        /// and applies them to the spec.
        /// </summary>
        /// <typeparam name="T1">The input type of the functions.</typeparam>
        /// <typeparam name="T2">The return type of the functions.</typeparam>
        /// <param name="spec">The spec object.</param>
        public static Func<IEnumerable<T1>, IDictionary<string, object>> ApplySpec<T1, T2>(
            this IDictionary<string, object> spec)
        {
            return Curry<IDictionary<string, object>, IEnumerable<T1>, IDictionary<string, object>>(
                ApplySpec<T1, T2>)(spec);
        }

        private static IDictionary<string, object> ApplySpec<T1, T2>(
            IDictionary<string, object> spec,
            List<T1> list,
            IDictionary<string, object> result)
        {
            foreach (var kvp in spec)
            {
                switch (kvp.Value)
                {
                    case Func<T1, T1, T2> func:
                        result[kvp.Key] = func(list[0], list[1]);
                        break;

                    case IDictionary<string, object> dict:
                        result[kvp.Key] = ApplySpec<T1, T2>(
                            dict,
                            list,
                            new Dictionary<string, object>());
                        break;

                    default:
                        result[kvp.Key] = kvp.Value;
                        break;
                }
            }

            return result;
        }
    }
}
