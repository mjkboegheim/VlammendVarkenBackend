let bestelLijst = JSON.parse(localStorage.getItem("winkelmandje")) || [];

function tekenBestelTabel() {
    
  const tbody = document.querySelector("tbody");
  tbody.innerHTML = "";

  if (bestelLijst.length === 0) {
    tbody.innerHTML = `
      <tr>
        <td class="px-4 py-3 font-semibold">-</td>
        <td class="px-4 py-3">-</td>
        <td class="px-4 py-3">-</td>
        <td class="px-4 py-3">-</td>
        <td class="px-4 py-3">-</td>
        <td class="px-4 py-3">-</td>
        <td class="px-4 py-3 text-right"></td>
        <td class="px-4 py-3 text-right font-semibold">€-</td>
      </tr>`
    ;
    updateTotaalPrijs(0);
    return;
  }

  let totaal = 0;
  
  bestelLijst.forEach((gerecht, index) => {
    totaal += parseFloat(gerecht.prijs);
    tbody.innerHTML += `
    <tr>
      <td class="px-4 py-3 font-semibold">${gerecht.naam}</td>
      <td class="px-4 py-3">${gerecht.soort || '-'}</td>
      <td class="px-4 py-3">${gerecht.bijgerecht || '-'}</td>
      <td class="px-4 py-3">${gerecht.groente || '-'}</td>
      <td class="px-4 py-3">${gerecht.saus || '-'}</td>
      <td class="px-4 py-3">${gerecht.allergenen || '-'}</td>
      <td class="px-4 py-3 text-right">
        <button class="text-red-500 hover:text-red-700" aria-label="Verwijderen" onclick="verwijderGerecht(${index})">
          <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6M1 7h22" />
          </svg>
        </button>
      </td>
      <td class="px-4 py-3 text-right font-semibold">€${parseFloat(gerecht.prijs).toFixed(2)}</td>
    </tr>`
    ;
  });
  updateTotaalPrijs(totaal);
}

function updateTotaalPrijs(totaal) {
  const totaalSpan = document.getElementById("totaalPrijs");
  totaalSpan.textContent = `€${totaal.toFixed(2)}`;
}

function verwijderGerecht(index) {
  bestelLijst.splice(index, 1);
  localStorage.setItem("winkelmandje", JSON.stringify(bestelLijst));
  tekenBestelTabel();
}

document.addEventListener("DOMContentLoaded", () => {
  tekenBestelTabel();

  const form = document.querySelector('form');
  if (!form) return;

  form.addEventListener('submit', function(e) {
    e.preventDefault();
    const data = new FormData(form);

    fetch(form.action, { method: 'POST', body: data})
    .then(response => {
      if (response.ok) {
        const nieuwGerecht = {
          naam: data.get('naam'),
          soort: data.get('soort') || '-',
          bijgerecht: data.get('bijgerecht') || '-',
          groente: data.get('groente') || '-',
          saus: data.get('saus') || '-',
          allergenen: data.get('allergenen') || '-',
          prijs: data.get('prijs') || '0.00',
        };

        bestelLijst.push(nieuwGerecht);
        localStorage.setItem("winkelmandje", JSON.stringify(bestelLijst));

        tekenBestelTabel();
        // alert('Gerecht toegevoegd!');
      
      } else {
        alert('Fout bij toevoegen');
      }
    }).catch(() => alert('Fout bij verbinding'));
  });
});
