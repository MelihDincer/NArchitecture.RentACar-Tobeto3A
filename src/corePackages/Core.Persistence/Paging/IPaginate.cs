namespace Core.Persistence.Paging;

public interface IPaginate<T>
{
    int From { get; }
    int Index { get; } //Kaçıncı sayfada olduğu (index=0 -> 1.sayfa)
    int Size { get; } // Kaçarlı listeleneceği
    int Count { get; } // Toplam data sayısı
    int Pages { get; } //Toplam sayfa sayısı
    IList<T> Items { get; }
    bool HasPrevious { get; } //Önceki sayfanın olup olmadığı
    bool HasNext { get; } //Sonraki sayfanın olup olmadığı
}