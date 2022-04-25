// C# IEnumerator interface reference:
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netframework-4.8

class PeekingIterator {
    IEnumerator<int> itr;
    bool hasNext;
    
    public PeekingIterator(IEnumerator<int> iterator) {
        itr = iterator;
        hasNext = true;
    }
    
    // Returns the next element in the iteration without advancing the iterator.
    public int Peek() {
        return itr.Current;     
    }
    
    // Returns the next element in the iteration and advances the iterator.
    public int Next() {
        var result = itr.Current;;
        hasNext = itr.MoveNext();
        
        return result;
    }
    
    // Returns false if the iterator is refering to the end of the array of true otherwise.
    public bool HasNext() {
        return hasNext;
    }
}

// class PeekingIterator1 {
//     Queue<int> pItr;
    
//     public PeekingIterator1(IEnumerator<int> iterator) {
//         var list = from item in iterator select item;
//         pItr = new Queue<int>(list);
//     }
    
//     // Returns the next element in the iteration without advancing the iterator.
//     public int Peek() {
//         return pItr.Peek();
//     }
    
//     // Returns the next element in the iteration and advances the iterator.
//     public int Next() {
//         return pItr.Dequeue();
//     }
    
//     // Returns false if the iterator is refering to the end of the array of true otherwise.
//     public bool HasNext() {
// 		return pItr.Count > 0;
//     }
// }