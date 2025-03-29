 OOP principi:
    
    1. Mantošana- Enemy un Player klase manto no Charactere klases. SwordWeapon, PotionWeapon, ShurikinWeapon, BasicWeapon, PoisionWeapons klases manto no Weapon klases.

    2. Enkapsulācija- Getter struktūra izmantota  Character klasē (44 - 47 līnija) nolasa active weapon un neļauj to mainīt. Setter struktūrta izmantota Character clasē (28 - 42 līnija), neļauj bleeding iet zem nulles.

    3. Polimorfisms- Overload funkcija izmantota Character klasē (63 - 69 līnija), paņem lietotā ieroča damage un atņem dzīvību. Override funkciju izmanto visās specifiskajās weapon klasēs, piemēram, PoisionWeapon,  (9 - 13 līnija), nomaina ko dara metode.

    4. Abstrakcija- SwordWeapon, PotionWeapon, ShurikinWeapon, BasicWeapon, PoisionWeapons klases manto no abstraktas Weapon klases (abstraktā metode line 14 un parasta metode line 9 - 12)


Papildus uzdevumi


    2 dažādi pretinieki ar atšķirīgiem uzbrukumiem - Ir trīs pretinieki (Berserker, Mushroom Man, Smelly Goblin) ar dažādiem ierošiem un pretinieks Berserker ar augošu agressiju.

    3 ieroču tipi, starp ko spēlētājs var izvēlēties - Potion Wepon (padar Enemy damage to Player mazāku, Damage 1 - 3 ), Sword Weapon (Iespēja iesist Chritical Damage kas ir 3 reizes lielāks nekā parastais Damage daudzums, Damage 2 - 8 ) un Shurikin Weapon (izdara Bleeding katrā turn izdara 10 bleed damage, kas turpina izdarīt damage pretiniekam, ja pat netiek izmantopts šis ierocis)

    Līmeņu sistēma spēlētājam - spēlētājam par katru nokauto pretinieku nāk klāt 5 XP punkti un, tos sakrājot, spēlētājs tiek nākamajā līmenī. Un Enemy paliek lielāka dzīvība līdz ar līmeni  tāpat kā spēlētājam(spēlētājs vel iegūst pluss 1 power, kas stiprāk sit par vienu punktu(attiecas uz visiem ieročiem) un vairāk atgūst health).

    Burvestības spēlētājam (buffs un healing) - spēlētājam ir iespējams sevi sadziedēt nospiežot Heal Spell button.

    Ir pieliktas background, healing un attack skaņas un vizuālais noformējums. 