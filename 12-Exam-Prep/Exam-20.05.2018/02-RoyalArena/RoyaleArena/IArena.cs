
using System.Collections.Generic;

public interface IArena : IEnumerable<Battlecard>
{
    void Add(Battlecard card);
    bool Contains(Battlecard card);

    int Count { get; }

    void ChangeCardType(int id, CardType type);

    Battlecard GetById(int id);
    void RemoveById(int id);


    IEnumerable<Battlecard> GetByCardType(CardType type);
    IEnumerable<Battlecard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo ,int hi);
    IEnumerable<Battlecard> GetByCardTypeAndMaximumDamage(CardType type, double damage);

    IEnumerable<Battlecard> GetByNameOrderedBySwagDescending(string name);
    IEnumerable<Battlecard> GetByNameAndSwagRange(string name, double lo, double hi);

    IEnumerable<Battlecard> GetAllByNameAndSwag();
    IEnumerable<Battlecard> FindFirstLeastSwag(int n);

    IEnumerable<Battlecard> GetAllInSwagRange(double lo, double hi);

}
