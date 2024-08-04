export function capitalizarPrimeraLetra(texto: string) :string {
    return texto.charAt(0).toUpperCase() + texto.slice(1).toLowerCase();
}