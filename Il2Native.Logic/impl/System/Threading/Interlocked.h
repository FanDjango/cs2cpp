
// Method : System.Threading.Interlocked.Exchange<T>(ref T, T)
template <typename T> 
T CoreLib::System::Threading::Interlocked::Exchange_Ref(T& location1, T value)
{
    throw 0xC000C000;
}

// Method : System.Threading.Interlocked.CompareExchange<T>(ref T, T, T)
template <typename T> 
T CoreLib::System::Threading::Interlocked::CompareExchange_Ref(T& location1, T value, T comparand)
{
    return __sync_val_compare_and_swap(&location1, value, comparand);
}