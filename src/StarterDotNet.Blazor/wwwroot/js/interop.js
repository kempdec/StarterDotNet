export function focusOnElementId(elementId) {
    let element = document.getElementById(elementId);
    if (element) {
        element.focus({ preventScroll: true });
    }
}
//# sourceMappingURL=interop.js.map