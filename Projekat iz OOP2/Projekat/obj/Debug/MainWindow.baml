   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjekatProjekat  5   	       Projekat.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Projekat     5   	   -   5          �Name$
  main��5   	    � WindowStyle$
 None=�6    � WindowStartupLocation$ CenterScreen=�5       � Title$ Login��5	   	   $	��800��6   $
��1000��6$    � DataContext 5   .   ��  �� RelativeSource �� *Self+.��5
      �� -   5        .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��50 200 0 0 q�6.   $��Center=�6C   .+�5      �� $��Unesite korisnicko ime: ��6   $��20(�68   $	��300��6F   �� 5      $��Center=�6   $��Center=�6:   $��20(�6�   $	��300��6�   $��40��6�   ��6\   �� *K.KorisnickoIme+ �� Mode$ TwoWay=�6�   5      �� 5   
   $ 
Horizontal=�6   $��
50 50 0 0 q�6.   $��Center=�6B   .+�5      �� $��Unesite lozinku: ��6   $��20(�61   $	��300��6?   G� 5      -   5         G�Name$ 
txtLozinka��5      $��20(�6/   $	��300��6>   $��40��6J   $��Center=�6V   $��Center=�6x   5      �� 5   
   -   5        $��	Uloguj se��5      $	��300��6%   $��40��61   $��20(�6=   $��50 50 50 50q�6K   6`   �� 5   
   -   5        $��Registruj se��5      $	��300��6(   $��40��64   $��20(�6@   6N   5      5      