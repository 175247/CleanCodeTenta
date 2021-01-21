- Vad du valt att testa och varför?
Tyckte inte att tiden riktigt räckte till så testade inte allt. Testade därför den endpoint där man skulle hämta en specifik film pga index m.m.
Testade också att listan sorterades, och hämtade topplistan sorterad, för att köra igenom det mesta.

- Vilket/vilka designmönster har du valt, varför? Hade det gått att göra på ett annat sätt?
Jag använde adapter då jag tidigt märkte att objekten var olika, men behövde se likadana ut för att sortera bl.a. Jag har inte jobbat med adapter förut.
Hade säkert gått att göra på andra sätt, men tiden var/är i skrivande stund knapp så ingen vidare utveckling kan ges på denna punkten just nu.

- Hur mycket valde du att optimera koden, varför är det en rimlig nivå för vårt program?
Jag hade velat optimera koden mer genom att bryta ut det till olika services och separera concerns. Det är inte bra när allt ligger i controllern. Jag fokuserade dock mer på att få in funktionaliteten och få det att fungera då tiden var knapp.
Koden är ändå på en rimlig nivå för tiden som angavs (för mig), men hade helt klart kunnat förbättras ytterligare, utan att göra det överkomplicerat.
Det är lite repetition där man skickar sin request och deserialiserar till objekt, men hade inte tid att göra det på ett bättre sätt med fler olika metoder.
