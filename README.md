# Diceware Password Generator

A KeePass 2 password generator plugin based on [Diceware](https://en.wikipedia.org/wiki/Diceware) and using wordlists provided by the [EFF](https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases).

## Installation

Download the latest release, unzip the contents of the release zip, and copy the following files into your `KeePass/Plugins` directory, preferably in a subfolder, e.g. `KeePass/Plugins/Diceware`:

- `DicewareGenerator.dll`
- `eff_short_wordlist.txt`
- `eff_large_wordlist.txt`
- `special_chars.txt`

**Note:** Because the plugin includes multiple files (namely the EFF wordlist), to avoid collisions with any other plugins, I'd recommend putting the files in a subfolder, as mentioned, however the plugin will work in the root of the Plugins folder just fine.  There's less chance of stepping on the toes of any other plugins if you run it from a subfolder as shown above, though, so it's just an extra precaution for yourself.

## Credits

- [Arnold Reinhold](https://theworld.com/~reinhold/diceware.html) for originally creating the idea of Diceware
- The [EFF](https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases) for providing a really well thought out Diceware word source.
- [That one XKCD comic](https://xkcd.com/936/) that got us all to take that type of password seriously.