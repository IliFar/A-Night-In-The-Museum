**KORTFATTAD**
[ [1] add-building [give it name] # Will add the building to the application ==> Jag valde kommandot add-building eftersom jag tror att det är det mest rimliga kommandot eftersom det representerar exakt vad kommandot är till för. Kommandot följs av byggnadens namn som ett argument. Till slut kommer kommandot att skrivas som följande "add-building building1" ]

[ [2] add-room [give it name] # Will add the room to specific building ==> Jag valde kommandot add-room eftersom jag tror att det är det mest rimliga kommandot eftersom det representerar exakt vad kommandot är till för. Kommandot följs av rummets namn som ett argument. Till slut kommer kommandot att skrivas som följande "add-room room1". ]

[ [3] delete-room # Will delete a room inside a specific building ==> Kommandot delete-room följs inte av ett argument denna gång eftersom vi behöver veta rummets namn som ska raderas och byggnadens namn där rummet finns. Så jag använde konsolklassen för att fånga namnen. ]

[ [4] add-art # Will add the art to a specific room ==> Kommandot add-art följs inte av ett argument eftersom vi behöver veta rummets namn som konst ska läggas till samt konsten's namn,skapar och beskrivning. Så jag använde konsolklassen för att fånga allt. ]

[ [5] show-art-in [room name] # Will show the arts in the specified room ==> Kommandot show-art-in följs av rumnamnet kommer visa all konst som finns i det rummet. ]

[ [6] show-all # Will show all the rooms and the art inside them ==> Kommandot show-all ska visa alla rum samt konsten som finns i varje rum. ]

[ [7] delete-art # Will a specific art in a given room ==> Jag valde kommandot delete-art eftersom jag tror att det är det mest rimliga kommandot eftersom det representerar exakt vad kommandot är till för. Kommandot följs inte av ett argument eftersom vi behöver veta konsten som ska raderas samt rummet där konsten finns. Så jag använde konsolklassen för att fånga allt.]

**SEPARATION**
För att skilja mina modellklasser från konsolklassen (System) gjorde jag 2 saker för att nå detta mål, den första är att jag inte använde uttalandet (using system;) i mina modellklasser, den andra saken är att istället för att använda konsolklassen i modellklasserna skapade jag [metoder] som kan ta in de [konsolinputs] som finns i klassen (VirtualMuseumProgram) som [argument] och sedan ta hand om dem i modellklasserna, en annan sak är [konstruktorn] i min modell klasser kan också ta in [konsolinputs] som ett [argument]. Slutligen ligger all användning av konsolklassen i klassen (VirtualMuseumProgram) som [kommunicerar-med-modellklasserna] genom att skicka in konsolinputs som [metodargument] eller [konstruktorargument].

**TESTING**
När det kommer till testning är jag fortfarande inte bra på det, men jag gjorde 4 tester. En är för att testa om en byggnad läggs till i byggnadslistan, en för att testa att ett rum läggs till i rumlistan, en för att testa att en konst läggs till i konst listan och den sista är för att testa att en konst läggs till ett specifikt rum (dock är jag inte säker på om jag gjort den på rätt sätt).
(1)[Test_Should_AddBuilding()] ==> i testet skapade jag en byggnad objekt, gav den en test sträng, sen läggar jag den i byggnadenslistan och asserta att den innehåller objektet [Assert.True(buildingList.Contains(building1))].

(2)[Test_Should_AddRoom()] ==> i testet skapade jag ett rum objekt, gav den en test sträng, sen läggar jag den i rumslistan och asserta att den innehåller objektet [Assert.True(roomList.Contains(room1))].

(3)[Test_Should_AddArt()] ==> i testet skapade jag en konst objekt, gav den 3 test stränger, sen läggar jag den i konstslistan och asserta att den innehåller objektet [Assert.True(artList.Contains(art1));].

(4)[Test_Should_AddArtInARoom()] ==> i testet skapade jag 2 listor(för rum och konst)sen skapar jag 2 objekt(för rum och konst), sen kollar jag om rummets namn är lika med test strängen som rummets objektet tar, om kravet uppfylls så kallar jag på en metod[AddArtToTheRoomAndReturnTheArt]som läggar till konsten i samband med rummets namn och returnerar en sträng med rummets namn och konsten som finns i det rummet. Till slut så asserta jag att strängen som metoden returnerar är equal till själva metoden.

**ANALYS**
Mitt program är inte robust, det finns många buggar och ingen undantagshantering förutom options argumentet som kontrollerar om options längd är mindre än 0 så skapar det ett nytt undantag.
Jag tror att jag hade några logiska problem som var lite knepiga att komma över, som ett exempel kopplingen mellan rummen och konsten, för att vara ärlig så förstår jag fortfarande inte hur de hänger ihop, även om jag fick det att fungera av kopplar konsten till rummets namn, men jag förstår fortfarande inte hur den kopplingen görs i kodens bakom kulisserna.
Jag har försökt använda ett gränssnitt(Interface), men jag märkte att jag kommer att göra mitt program lite mer komplext än nödvändigt eftersom jag fokuserade på att få programmet att fungera och implementera all nödvändig logik och struktur. Men förhoppningsvis får jag en chans att använda ett gränssnitt(Interface) i ett framtida projekt.
