/**
 * Foca em um elemento HTML, se houver algum, que possui o identificador especificado.
 * 
 * @param elementId O identificador do elemento HTML a ser buscado.
 */
export function focusOnElementId(elementId: string) {

    let element = document.getElementById(elementId);

    if (element) {

        element.focus({ preventScroll: true });
    }
}