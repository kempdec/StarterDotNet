export function copyToClipboard(text) {
    return navigator.clipboard.writeText(text)
        .then(() => true)
        .catch(() => false);
}
export function disableBtnId(btnId) {
    let btn = document.getElementById(btnId);
    if (btn) {
        btn.disabled = true;
    }
}
export function enableBtnId(btnId) {
    let btn = document.getElementById(btnId);
    if (btn) {
        btn.disabled = false;
    }
}
export function focusOnElementId(elementId) {
    let element = document.getElementById(elementId);
    if (element) {
        element.focus({ preventScroll: true });
    }
}
export function getReferrer() {
    return document.referrer;
}
//# sourceMappingURL=interop.js.map