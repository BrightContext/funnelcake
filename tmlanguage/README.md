# Sublime Text and TextMate support

Sublime Text 2

    cd ~/Library/Application\ Support/Sublime\ Text\ 2/Packages/User
    curl -O https://raw.github.com/BrightContext/funnelcake/master/tmlanguage/funnelcake.tmLanguage

Sublime Text 3

    cd ~/Library/Application\ Support/Sublime\ Text\ 3/Packages/User
    curl -O https://raw.github.com/BrightContext/funnelcake/master/tmlanguage/funnelcake.tmLanguage

Reboot sublime text and it should now pick up `*.cake` and `*.funnelcake` files after creating it's tmLanguage.cache automatically.

If not, open a `.cake` file and from the bottom right corner select

  Plain Text > Open all with current extension as ... > FunnelCake
