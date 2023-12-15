/**
 * Copia o texto especificado para a área de transferência.
 * 
 * @param text O texto a ser copiado para a área de transferência.
 * @returns A promessa que representa a operação assíncrona, contendo um sinalizador indicando se o texto especificado
 * foi copiado para a área de transferência.
*/
export function copyToClipboard(text: string): Promise<Boolean> {

    return navigator.clipboard.writeText(text)
        .then(() => true)
        .catch(() => false);
}

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