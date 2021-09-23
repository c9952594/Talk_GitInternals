# Introduction

**Going to use VSCode because it has:**

- Git support
- Markdown support
- C# support
- File exploration
- Integrated terminals
- Image viewers

_More importantly it's my default IDE and I know the shortcuts_

**I'm going to git-bash/shell because I prefer it when working with git**

```
C:\Program Files\Git\bin\sh.exe
```

## My aim today

- That this diagram should make sense.
- That you feel comfortable that you can't completely screw up a merge/rebase.

![](EndGame.png)

## Tooling

I've written an extension to dump out git information.

```
git alldetails
```

The extension will need to be our path.

```
PATH=`pwd`:$PATH
```

We can view use this in a differencing tool to see change of state.

```
cat right.txt > left.txt && git alldetails > right.txt
```
