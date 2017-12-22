# Card_Writer
C# program. Jedná se o nádstavbu pro několik skriptů powershellu, sloužící k zápisu karet do ADčka. 

Funkce: 
- powershell skripty pro komunikaci s AD
  - Vyhledání sAMAccountname (vytvoření instance třídy ADuser s informacemi o uzivately)
  - Vyhledání otherPager.
  - Zápis otherPager (podle sAMAccountname)
  - Smazání hodnot otherPager (podle sAMAccountname)
- převod čísel
  - Z Decimální do Hexadecimální (+ připojení prefixu)
  - Z Hexadecimální do Decimální (+ odpojení  prefixu)
