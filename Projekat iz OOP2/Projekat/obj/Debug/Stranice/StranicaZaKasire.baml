   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Projekat.StraniceProjekat.Stranice  5      (    "Projekat.Stranice.StranicaZaKasire   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Projekat.Stranice     5      $
��1000��5   1     N� Title$  StranicaZaKasire��5	       N� 
Background
 ����� � DataContext 5      ��  �� RelativeSource �� *Self+ � 	Resources 5
       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ 24(�6)   �� 5       � ��$ Center=�62   �� 5       � ��$ 50��6'   5      5      .��5      �� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $
��1000��6.   $��50��6;   $��	0 25 0 20q�6G   .+�5      �� -   5        	 ��Name$	 txtKorisnik��5      $��	Korisnik:��6-   $��25(�6>   $��	50 10 0 0q�6L   �� 5      -   5        $��	Odjavi se��5      $��20(�6>   $	��100��6L   $��30��6X   $��	650 0 0 0q�6d   5      �� 5   
   $
��1000��6   $��50��6"   $ 
Horizontal=�6.   $��0 0 0 10q�6G   .+�5      �� $��Nacin placanja��6   $��40��6.   $��20(�6:   $	��150��6H   $��	50 5 60 0q�6T   �� 5      $ 
Horizontal=�6   $	��670��62   .+�5      	� -   5        
 d� 	IsChecked$
 FalseY�5   <   $��Gotovina��6N   $��20(�6a   $��0 0 20 0q�6o   $��Center=�6�   $��Center=�6�    	� 	GroupName$ NacinPlacanja��6�   	� 5      -   5        $
 FalseY�5   <   $��Debitna kartica��6N   $��20(�6h   $��0 0 20 0q�6v   $��Center=�6�   $��Center=�6�   $ NacinPlacanja��6�   	� 5      -   5        $
 FalseY�5   <   $��Kreditna kartica��6N   $��20(�6i   $��0 0 20 0q�6w   $��Center=�6�   $��Center=�6�   $ NacinPlacanja��6�   	� 5      -   5        $
 FalseY�5   <   $��Digitalni novcanik��6N   $��20(�6k   $��0 0 20 0q�6y   $��Center=�6�   $��Center=�6�   $ NacinPlacanja��6�   5      5      �� 5    
   $ 
Horizontal=�6   .+�5!      �� $ Vertical=�6   $	��500��60   $	��350��6<   .+�5"      �� $��Ponudjeni proizvodi��6   $��	80 0 0 20q�67   �� 5#      -   5         ��Name$ lvPonudjeniProizvodi��5#      $	��250��6r   $
��Left=�6   $	��480��6�   $��10 0 0 0q�6�   $��20(�6�    �� View 5$      �� 5%      .P�5&      �� $��Bar Kod��6-    �� Width$	 120��6>    �� DisplayMemberBinding 6J   �� *BarKod+�� 5'      $	��Ime��6-   $	 120��6:    6F   �� *Ime+�� 5(      $
��Cena��6-   $	 120��6;    6G   �� *Cena+�� 5)      $��Kolicina��6-   $	 120��6?    6K   �� *
Kolicina+5*      5,      5-      �� 5.      $	��500��6   $	��350��6%   .+�5/      �� $��Korpa:��6   $��
200 0 0 20q�6*   �� 50      -   5        $ lvKorpa��50      $	��250��6,   $
��Left=�69   $	��480��6T   $��0 0 0 0q�6`   $��20(�6q    51      �� 52      .P�53      �� $��Bar Kod��6-   $	 120��6>    6J   �� *BarKod+�� 54      $	��Ime��6-   $	 120��6:    6F   �� *Ime+�� 55      $
��Cena��6-   $	 120��6;    6G   �� *Cena+�� 56      $��Kolicina��6-   $	 120��6?    6K   �� *
Kolicina+57      59      5:      5;      �� 5<   
   $ 
Horizontal=�6   $	��100��6.   $��0 0 0 0q�6;   .+�5=      �� $ Vertical=�6   $��	180 0 0 0q�60   .+�5>      �� $��Odabrani proizvod:��6   $��50��66   $��24(�6B   $��	10 0 0 0 q�6P   �� 5?      -	   5         ��Name$ trText��5?   n   $	��200��6   $��	0 -10 0 0q�6'   $��50��6:   $��20(�6F   6n   5@      �� 5A      $ Vertical=�6   $��	100 0 0 0q�60   .+�5B      �� $��Zeljena kolicina(Kg):��6   $��	10 0 0 0 q�6:   �� 5C      $	��200��6   $��	0 -10 0 0q�6'   $��50��6:   $��20(�6F   ��6U   �� *TrProizvod.Kolicina+ �� Mode$ TwoWay=�5D      �� 5E      -
   5         ��Name$ 	btnUKorpu��5E      $��Ubaci u korpu��6D   $	��150��6\   $��50��6h   $��	100 0 0 0q�6t   $��20(�6�   5F      �� 5G   
   $	��100��6   $
��1000��6"   $ 
Horizontal=�6/   .+�5H      �� $ Vertical=�6   $��	190 0 0 0q�60   .+�5I      �� $��Uplata:��6   $��	60 0 30 0q�6'   �� 5J      $	��200��6:   $��24(�6F   $��50��6T   $��Center=�6`   ��6   �� *Uplata+$ TwoWay=�6`   5K      �� 5L      $ Vertical=�6   $��	110 0 0 0q�60   .+�5M      �� $��
Popust(%):��6   $��	50 0 50 0q�6/   �� 5N      $��24(�6>   $	��200��6L   $��50��6X   $��Center=�6d   ��6   �� *Popust+$ TwoWay=�6d   5O      �� 5P      -   5        $ 
btnNaplati��5P      $��Naplati��6F   $	��150��6X   $��50��6d   $��	100 0 0 0q�6p   $��24(�6�   5Q      5R      5S      