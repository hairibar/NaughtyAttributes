This is a fork of [NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes) that I use to add my own extensions to it. Most of the work that has gone into this repo is not mine.

[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://github.com/hairibar/NaughtyAttributes/blob/master/LICENSE)

NaughtyAttributes is an extension for the Unity Inspector.

It expands the range of attributes that Unity provides so that you can create powerful inspectors without the need of custom editors or property drawers. It also provides attributes that can be applied to non-serialized fields or functions.

Most of the attributes are implemented using Unity's `CustomPropertyDrawer`, so they will work in your custom editors. If you want all of the attributes to work in your custom editors, however, you must inherit from `NaughtyInspector` and use the `NaughtyEditorGUI.PropertyField_Layout` function instead of `EditorGUILayout.PropertyField`.

## Installation
You can install this package via git url by adding this entry in your **manifest.json**
```
"com.hairibar.naughtyattributes": "https://github.com/hairibar/NaughtyAttributes.git#upm"
```
