namespace DecisionRules
{
    /// <summary>
    /// Represents the context in which rules and decision trees are evaluated.
    /// </summary>
    public class Context
    {
        /// <summary>
        /// The internal storage for context data.
        /// </summary>
        private readonly Dictionary<string, object> _data = new Dictionary<string, object>();

        /// <summary>
        /// Sets or updates a value in the context by key.
        /// </summary>
        /// <param name="key">The key for the data.</param>
        /// <param name="value">The value to set.</param>
        public void SetData(string key, object value)
        {
            _data[key] = value;
        }

        /// <summary>
        /// Retrieves a value from the context by key.
        /// </summary>
        /// <param name="key">The key for the data.</param>
        /// <returns>The value associated with the key, or null if not found.</returns>
        public object GetData(string key)
        {
            _data.TryGetValue(key, out var value);
            return value;
        }

        /// <summary>
        /// Retrieves a typed value from the context by key.
        /// </summary>
        /// <typeparam name="T">The type of the value to retrieve.</typeparam>
        /// <param name="key">The key for the data.</param>
        /// <returns>The typed value associated with the key, or the default value for the type if not found.</returns>
        public T GetData<T>(string key)
        {
            if (_data.TryGetValue(key, out var value))
            {
                return (T)value;
            }

            return default;
        }

        /// <summary>
        /// Checks if the context contains a specific key.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>True if the key exists, false otherwise.</returns>
        public bool ContainsKey(string key)
        {
            return _data.ContainsKey(key);
        }

        /// <summary>
        /// Removes a value from the context by key.
        /// </summary>
        /// <param name="key">The key for the data to remove.</param>
        /// <returns>True if the key was found and the value was removed, false otherwise.</returns>
        public bool RemoveData(string key)
        {
            return _data.Remove(key);
        }

        /// <summary>
        /// Clears all data from the context.
        /// </summary>
        public void Clear()
        {
            _data.Clear();
        }
    }
}