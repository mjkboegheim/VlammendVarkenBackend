// let bestelling = JSON.parse(localStorage.getItem("winkelmandje")) || [];
//
// document.addEventListener("DOMContentLoaded", () => {
//   document.querySelectorAll(".toevoegenBtn").forEach((btn) => {
//     btn.addEventListener("click", () => {
//       const gerecht = {
//         naam: btn.dataset.naam,
//         soort: btn.dataset.soort || "",
//         bijgerecht: btn.dataset.bijgerecht || "",
//         groente: btn.dataset.groente || "",
//         saus: btn.dataset.saus || "",
//         allergenen: btn.dataset.allergenen || "",
//         prijs: parseFloat(btn.dataset.prijs || "0").toFixed(2),
//       };
//
//       bestelling.push(gerecht);
//       localStorage.setItem("winkelmandje", JSON.stringify(bestelling));
//       tekenBestelTabel();
//     });
//   });
//
//   tekenBestelTabel();
// });
//
// function tekenBestelTabel() {
//   const tbody = document.getElementById("bestelTabel");
//   tbody.innerHTML = "";
//
//   let totaal = 0;
//
//   bestelling.forEach((gerecht, index) => {
//     totaal += parseFloat(gerecht.prijs);
//     tbody.innerHTML += `
//       <tr>
//         <td class="p-2">${gerecht.naam}</td>
//         <td class="p-2">${gerecht.soort || ""}</td>
//         <td class="p-2">${gerecht.bijgerecht || ""}</td>
//         <td class="p-2">${gerecht.groente || ""}</td>
//         <td class="p-2">${gerecht.saus || ""}</td>
//         <td class="p-2">${gerecht.allergenen || ""}</td>
//         <td class="p-2 text-right">
//           <button onclick="verwijder(${index})" class="text-red-500">Verwijder</button>
//         </td>
//         <td class="p-2 text-right">€${gerecht.prijs}</td>
//       </tr>
//     `;
//   });
//
//   document.getElementById("totaalPrijs").textContent = `€${totaal.toFixed(2)}`;
// }
//
// function verwijder(index) {
//   bestelling.splice(index, 1);
//   localStorage.setItem("winkelmandje", JSON.stringify(bestelling));
//   tekenBestelTabel();
// }
