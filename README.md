A C# script that automates the **LuccaFaces** game by recognizing images and submitting answers to achieve high scores automatically.
This script connects to the LuccaFaces game, retrieves questions, processes the image via hashing, and automatically selects the correct suggestion if recognized.

To authenticate, the script needs your `authToken` cookie. Here's how to find it:

1. Open https://[your company].ilucca.net/faces in your web browser.
2. Press `F12` to open the **Developer Tools**.
3. Go to the **Network** tab.
4. Refresh the page (`F5`) and click on any request like `games`.
5. Look under the **Headers** section for a `Cookie` header.
6. Find a value like: authToken=7edb8a0d-c95a-4002-b6e2-**********

To obtain the hashes dictionary, open your browser's developer console (press F12, go to the Console tab), copy the content of the hash-capture.js file, paste it into the console, and press Enter.
Then, click on the correct answers during the game. Each click will log the SHA-256 hash of the displayed image, associated with the selected name.
