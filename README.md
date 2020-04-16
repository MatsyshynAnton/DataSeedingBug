### Data Seeding bug
#### The problem: cannot explicity initialize generated values while using data seeding.
#### Description:
This project was created to demonstrate bug in data seeding when you using generated values. There is entity `User` with two generated properties: `Created` and `Modified`. When I'm using data seeding for inserting test data into table `Users` and **explicity** initialize both of generated values, property `Modified` isn't initialize in migration (unlike `Created`).

Generated properties attributes:
```
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public DateTime Created { get; set; }

[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
public DateTime Modified { get; set; }
```

These rows I want to insert via data seeding (13-th row in DatabaseContext):
```
modelBuilder.Entity<User>().HasData(new User[]
            {
                new User{Id=1, FirstName="John", LastName="Gold", Age=27, Created=DateTime.Now, Modified=DateTime.Now},
                new User{Id=2, FirstName="Ronald", LastName="Weasley", Age=16, Created=DateTime.Now, Modified=DateTime.Now},
                new User{Id=3, FirstName="Sherlock ", LastName="Holmes", Age=18, Created=DateTime.Now, Modified=DateTime.Now}
            });
```

And here is a migration:
```
migrationBuilder.InsertData(
      table: "Users",
      columns: new[] { "Id", "Age", "Created", "FirstName", "LastName" },
      values: new object[] { 1L, 27, new DateTime(2020, 4, 16, 12, 13, 34, 841, DateTimeKind.Local).AddTicks(4524), "John", "Gold" });

migrationBuilder.InsertData(
      table: "Users",
      columns: new[] { "Id", "Age", "Created", "FirstName", "LastName" },
      values: new object[] { 2L, 16, new DateTime(2020, 4, 16, 12, 13, 34, 845, DateTimeKind.Local).AddTicks(126), "Ronald", "Weasley" });

migrationBuilder.InsertData(
      table: "Users",
      columns: new[] { "Id", "Age", "Created", "FirstName", "LastName" },
      values: new object[] { 3L, 18, new DateTime(2020, 4, 16, 12, 13, 34, 845, DateTimeKind.Local).AddTicks(199), "Sherlock ", "Holmes" });

```

As you can see, I specify `Modified` value, while using data seeding, but this property is not initialized in migration. 
