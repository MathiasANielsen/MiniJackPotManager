MiniJackpotManager

Backend
1. Build the backend code
2. dotnet ef migrations add InitialCreate
3. dotnet ef database update
4. Run it

Frontend
5. build frontend code 
6. npm start

Test
7. Open test project 
8. run dotnet test



To insert data into the database write the following query 
INSERT INTO Jackpot (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (1, 'Jackpot A', 100, 1000, 10);
INSERT INTO Jackpot (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (2, 'Jackpot B', 200, 1100, 20);
INSERT INTO Jackpot (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (3, 'Jackpot C', 300, 1200, 200);
INSERT INTO Jackpot (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (4, 'Jackpot D', 400, 1300, 300);
INSERT INTO Jackpot (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (5, 'Jackpot E', 500, 2000, 250);
INSERT INTO Jackpot (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (6, 'Jackpot F', 600, 2100, 350);
INSERT INTO Jackpot (Id, Name, SeedValue, HitThreshold, CurrentValue)
VALUES (7, 'Jackpot G', 700, 3000, 100);
