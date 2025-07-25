(() => {
  const hashes = {};

  async function hashImage(url) {
    const res = await fetch(url, { cache: 'no-store' });
    const blob = await res.blob();
    const arrayBuffer = await blob.arrayBuffer();
    const hashBuffer = await crypto.subtle.digest("SHA-256", arrayBuffer);
    const hashArray = Array.from(new Uint8Array(hashBuffer));
    return hashArray.map(b => b.toString(16).padStart(2, "0")).join("");
  }

  async function processAnswerClick(event) {
    const answer = event.currentTarget;
    const name = answer.innerText.trim();
    if (!name) return;

    const imgEl = document.querySelector("#game app-timer .image");
    if (!imgEl) return;

    const style = getComputedStyle(imgEl);
    const url = style.backgroundImage.slice(5, -2); // Strip url("...")

    try {
      const hash = await hashImage(url);
      if (!hashes[hash]) {
        hashes[hash] = name;
        console.log(`["${hash}"] = "${name}",`);
      }
    } catch (err) {
      console.warn("Hashing failed:", err);
    }
  }

  function bindAnswers() {
    document.querySelectorAll(".answers .answer").forEach(btn => {
      btn.removeEventListener("click", processAnswerClick);
      btn.addEventListener("click", processAnswerClick);
    });
  }

  const mutationObserver = new MutationObserver(() => bindAnswers());
  mutationObserver.observe(document.body, { childList: true, subtree: true });
})();
