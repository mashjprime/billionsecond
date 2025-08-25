const calculateBtn = document.getElementById("calculate");
const results = document.getElementById("results");
const billionDateEl = document.getElementById("billion-date");
const countdownEl = document.getElementById("countdown");
const ageBreakdownEl = document.getElementById("age-breakdown");
let ticker;

calculateBtn.addEventListener("click", () => {
  const dobValue = document.getElementById("dob").value;
  if (!dobValue) {
    alert("Please select your date of birth.");
    return;
  }
  const birthDate = new Date(dobValue);
  const billionDate = new Date(birthDate.getTime() + 1e9 * 1000);

  billionDateEl.textContent = `You become a billion seconds old on ${billionDate.toLocaleString()}`;
  results.classList.remove("hidden");

  if (ticker) clearInterval(ticker);

  function update() {
    const now = new Date();
    const diff = billionDate - now;

    if (diff <= 0) {
      countdownEl.textContent =
        "Congratulations! You've passed the billion second mark!";
      clearInterval(ticker);
    } else {
      const sec = Math.floor(diff / 1000);
      countdownEl.textContent = `Time until then: ${formatDuration(sec)}`;
    }

    const ageSec = Math.floor((now - birthDate) / 1000);
    const ageData = [
      ["Seconds", ageSec],
      ["Minutes", (ageSec / 60).toFixed(2)],
      ["Hours", (ageSec / 3600).toFixed(2)],
      ["Days", (ageSec / 86400).toFixed(2)],
      ["Weeks", (ageSec / (86400 * 7)).toFixed(2)],
      ["Months", (ageSec / (86400 * 30.44)).toFixed(2)],
      ["Years", (ageSec / (86400 * 365.25)).toFixed(2)],
      ["Centuries", (ageSec / (86400 * 365.25 * 100)).toFixed(2)],
      ["Millennia", (ageSec / (86400 * 365.25 * 1000)).toFixed(2)],
    ];
    ageBreakdownEl.innerHTML = ageData
      .map(([label, value]) => `<li><strong>${label}:</strong> ${value}</li>`) //
      .join("");
  }

  update();
  ticker = setInterval(update, 1000);
});

function formatDuration(totalSeconds) {
  const s = totalSeconds % 60;
  const m = Math.floor(totalSeconds / 60) % 60;
  const h = Math.floor(totalSeconds / 3600) % 24;
  const d = Math.floor(totalSeconds / 86400);
  return `${d}d ${h}h ${m}m ${s}s`;
}
