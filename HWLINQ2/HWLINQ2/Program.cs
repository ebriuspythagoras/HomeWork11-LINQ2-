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





