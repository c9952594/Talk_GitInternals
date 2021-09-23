# Introduction

You can find this repo here: https://github.com/c9952594/Talk_GitInternals

**VSCode**

Going to use VSCode because it has:

- Git support
- Markdown support
- C# support
- File exploration
- Integrated terminals
- Image viewers

*More importantly it's my default IDE, ***it's awesome***, and I know the shortcuts*

**Shell**

I'm going to git-bash/shell because I prefer it when working with git.

```
C:\Program Files\Git\bin\sh.exe
```

There is nothing I'm doing in here that won't also work with your Command Line Interface of choice.

## My aim today

1. That you feel comfortable that you can't completely screw up a merge/rebase/etc.
2. That this diagram should make sense.

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

## Rough agenda

- Objects
  - Git init
    - Show files
  - First Commit (BlobA)
    - Show files
      - Focus on objects
  - Second commit
    - ObjectCreator (C#)
      - Show Blob
      - Explain Tree / Commit
      - Export (BlobB)
    - Different trees / Same blobs
      - Blobs aren't files
      - Trees give context
      - Each commit has a tree
        - Each commit is complete
      - Differences aren't stored but calculated
  - Third Commit
    - With subtree + new file (Blob C)
- Index
  - Notice staging before committing
  - What does this mean?
    - Alter the index file to store blobs
  - When you commit trees are made from index
  - Alter bak/BlobA
    - Modified
      - Notice the new hash
    - Stage
      - Old out / New in
    - Unstage
  - Add new
    - Untracked
      - Stage
      - Show blob
      - Unstage
      - Not removed
  - Delete 
    - Show Deleted
    - Stage
    - Commit
    - Notice objects aren't removed
      - Garbage collector
- Refs
  - Objects live seperate lives
  - 