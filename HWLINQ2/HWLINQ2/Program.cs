using HWLINQ2;

var data = new List<object>() {
  "Hello",
  new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
  new List<int>() {4, 6, 8, 2},
  new string[] {"Hello inside array"},
  new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
    new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
    new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
    new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
  }},
  new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
    new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
    new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
}},
  new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
  "Leonardo DiCaprio"
};

//1. Виведіть усі елементи, крім ArtObjects
Console.WriteLine(String.Join(", ", data.Except(data.OfType<ArtObject>()).ToArray()));

//2. Виведіть імена всіх акторів
Console.WriteLine(String.Join(",", data.OfType<Film>().SelectMany(l => l.Actors).Select(a => a.Name)));

//3. Виведіть кількість акторів, які народилися в серпні
Console.WriteLine(String.Join(",", data.OfType<Film>().SelectMany(a => a.Actors).Where(a => a.Birthdate.Month == 8).Select(a => a.Name).Distinct()));

//4. Виведіть два найстаріших імена акторів
Console.WriteLine(String.Join(",", data.OfType<Film>().SelectMany(l => l.Actors).OrderBy(a => a.Birthdate).Take(2).Select(a => a.Name)));

//5. Вивести кількість книг на авторів
Console.WriteLine(String.Join(",", data.OfType<Book>().GroupBy(b => b.Author).Select(b => new { Autor = b.Key, CountOfBooks = b.Count() }).ToList()));

//6. Виведіть кількість книг на одного автора та фільмів на одного режисера
Console.WriteLine(String.Join(",", data.OfType<ArtObject>().GroupBy(a => a.Author).Select(a => new { Author = a.Key, Count = a.Count() }).ToList()));

//7. Виведіть, скільки різних букв використано в іменах усіх акторів
Console.WriteLine(String.Concat(data.OfType<Film>().SelectMany(a => a.Actors).SelectMany(a => a.Name)).Split(' ').SelectMany(c => c).Distinct().Count());

//8. Виведіть назви всіх книг, упорядковані за іменами авторів і кількістю сторінок
Console.WriteLine(String.Join(",\n", data.OfType<Book>().OrderBy(b => b.Author).ThenBy(b => b.Pages).Select(b => b.Name).ToArray()));

//9. Виведіть ім'я актора та всі фільми за участю цього актора
Console.WriteLine(
   String.Join(",", from actor in data.OfType<Film>().SelectMany(f => f.Actors)
                    group actor by actor.Name into g
                    select new
                    {
                        ACTOR = g.Key,
                        FILMS = String.Join(",", data.OfType<Film>()
                                                     .Where(f => f.Actors.Contains(g.First()))
                                                     .Select(f => f.Name))
                    }
));

//10.Виведіть суму загальної кількості сторінок у всіх книгах і всі значення int у всіх послідовностях у даних
Console.WriteLine(String.Concat("Total pages: ", data.OfType<Book>().Select(b => b.Pages).Sum().ToString(), ", ints in lists: ", String.Join(", ", data.OfType<List<int>>().SelectMany(i => i.OfType<int>()).ToList())));

//11.Отримати словник з ключем - автор книги, значенням - список авторських книг
Console.WriteLine(String.Join(", ", data.OfType<Book>().GroupBy(b => b.Author).ToDictionary(g => "AUTHOR: " + g.Key, g => "BOOKS: \"" + String.Join(", ", g.Select(b => b.Name + "\"").ToList()))));

//12. Вивести всі фільми "Метт Деймон", за винятком фільмів з акторами, імена яких представлені в даних у вигляді рядків
Console.WriteLine(
    String.Join(",",
    (from film in data.OfType<Film>()
     from actor in film.Actors
     where actor.Name == "Matt Damon"
     select film.Name)
         .Except(
        from film in data.OfType<Film>()
        from actor in film.Actors
        where data.OfType<string>().Any(a => a == actor.Name)
        select film.Name
        )
    ));







