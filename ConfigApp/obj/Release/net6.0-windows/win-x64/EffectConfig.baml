   M S B A M L   `   `   `  ����   ChaosModVConfig    ConfigApp.EffectConfig   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Effect Config��$	��400��$	��700�� � 
ResizeMode$ NoResize=�.���  � ColumnDefinitions �� $	��370 ��� $��10 ���  � RowDefinitions �� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��45 ��� $��40 ��� $��40 ��� $��30 ��� .+��� $��Rename Effect��$��0��$��0��$��Right=�$��Center=��� -    ��Name$# effectconf_effect_custom_name��$��20��$	��120��$��2��$
��Left=�$��Center=� �� 	MaxLength$ 30���� $ ��Override Timed Effect Type��$��1��$��0��$��Right=�$��Center=��� -    ��Name$" effectconf_timer_type_enable��$��1��$��2��$
��Left=�$��Center=�$��Center=��� -    ��Name$ effectconf_timer_type��$��25��$	��120��$��40,0,0,0q�$��1��$��2��$
��Left=�$��Center=�${�False���� $2��,Override Timed Effect Timer Length (Seconds)��$��2��$��0��$��Right=�$��Center=��� -   $" effectconf_timer_time_enable��$��2��$��2��$
��Left=�$��Center=�$��Center=��� -   $ effectconf_timer_time��$��20��$��60��$��40,0,0,0q�$��2��$��2��$
��Left=�$��Center=�${�False��$ 6�� � ContextMenu Z� �� -   	 ��Name$)	 #effectconf_effect_weight_mult_title��$p��jSet Effect Weight Multiplier (Affects chances of this effect occuring)
lowest: 1, highest: 10, default: 5��$��3��$��0��$��Right=�$��Center=��� -   $# effectconf_effect_weight_mult��$��25��$	��100��$��3��$��2��$
��Left=�$��Center=��� -   $,	 &effectconf_exclude_voting_enable_title��$ ��Exclude Effect from Voting��$��4��$��0��$��Right=�$��Center=��� -	   $% effectconf_exclude_voting_state��$��25��$	��100��$��4��$��2��$
��Left=�$��Center=��� -
   $*	 $effectconf_effect_shortcut_key_title��$��Shortcut (ESC to reset)��$��5��$��0��$��0,5.667,0,10.333q�$��Right=�$	��360��$��Right=��� -   $' !effectconf_effect_shortcut_enable��$��5��$��2��$
��Left=�$��Center=�$��Center=��� -   $&  effectconf_effect_shortcut_input��$��5��$��2��$��
40,10,0,10q�
 J� 	AllowDrop$
 False��$��20�� �� IsUndoEnabled$ False�� �� 
IsReadOnly$
 True��$��Center=�$
��Left=�$
��None��$	��120��${�False�� �� SelectionBrush Z� �� -    ��Name$ effectconf_mp3_label��$��7��$��0��$��3��$��10(�$��Center=�$��Center=��� -   $
��Save��$��40��$��75��$��0,0,5,0q�$��8��$��2��$��Right=�$��Center=�