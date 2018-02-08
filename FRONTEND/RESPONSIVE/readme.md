So, because the main goal is to adopt given UI for mobile devices, there is several things that I would do:
1. Because the size of screen on mobile is quite smaller than on desktop we need to hide all menu's under Hamburger menu. Structure of
such menu can be:
    - [UserName] [Logout](Logout)
    - Administration
    - Preferences
    - History
    - Actions
        - Page Operations
        - Browse Space
        - Add Content
2. Action links like "Show children | View in hierarchy ..." can be replaced with icons, something like glyphicons in Bootstrap or FontAwesome
3. Button "Print" is not necessary.
4. From the top menu, where is the search box, I would remove "Breadcrumbs", and instead of them I would added a logo and burger menu button
