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
 * Desabilita um botão, se houver algum, que possui o identificador especificado.
 * 
 * @param btnId O identificador do botão a ser buscado.
 */
export function disableBtnId(btnId: string) {

    let btn = document.getElementById(btnId) as HTMLButtonElement;

    if (btn) {

        btn.disabled = true;
    }
}

/**
 * Habilita um botão, se houver algum, que possui o identificador especificado.
 * 
 * @param btnId O identificador do botão a ser buscado.
 */
export function enableBtnId(btnId: string) {

    let btn = document.getElementById(btnId) as HTMLButtonElement;

    if (btn) {

        btn.disabled = false;
    }
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

/**
 * Obtém a URL do local que referenciou o usuário para a página atual.
 * 
 * @returns A URL do local que referenciou o usuário para a página atual.
 */
export function getReferrer(): string {

    return document.referrer;
}