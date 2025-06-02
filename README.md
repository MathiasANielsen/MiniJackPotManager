MiniJackpotManager

Backend
1. Change connection string in appsettings
2. Build the backend code
3. write in terminal dotnet ef migrations add InitialCreate
4. write in terminal dotnet ef database update
5. Run it

Frontend
1. build frontend code
2. write npm start in the terminal 

Test
1. Open test project 
2. run dotnet test



To insert data into the database write the following query: 
INSERT INTO Jackpots (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (1, 'Jackpot A', 100, 1000, 10);
INSERT INTO Jackpots (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (2, 'Jackpot B', 200, 1100, 20);
INSERT INTO Jackpots (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (3, 'Jackpot C', 300, 1200, 200);
INSERT INTO Jackpots (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (4, 'Jackpot D', 400, 1300, 300);
INSERT INTO Jackpots (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (5, 'Jackpot E', 500, 2000, 250);
INSERT INTO Jackpots (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (6, 'Jackpot F', 600, 2100, 350);
INSERT INTO Jackpots (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (7, 'Jackpot G', 700, 3000, 100);
