var setInteractionType = function (type) {
    if (type === 'Mouse') {
        document.body.classList.remove('e-bigger');
    } else {
        document.body.classList.add('e-bigger');
    }
};

var setDisableIcons = function (id, value) {
    let toolbarItem = document.getElementById(id);
    if (value) {
        toolbarItem.classList.add("e-disabled");
        toolbarItem.setAttribute("disabled", "true");
    } else {
        toolbarItem.classList.remove("e-disabled");
        toolbarItem.removeAttribute("disabled");
    }
};

var getWindowWidth = function () {
    return window.innerWidth;
};

var toggleAltRowStyle = function (enable, themeName) {
    let styleTag = document.getElementById("altrow-style");
    if (enable) {
        if (!styleTag) {
            styleTag = document.createElement("style");
            styleTag.id = "altrow-style";
            document.head.appendChild(styleTag);
        }
        styleTag.innerHTML = themeName.includes('dark') ? `.e-grid .e-altrow { background-color: #000156 !important; }` : `.e-grid .e-altrow { background-color: #FFFF61 !important; }`;
    } else {
        if (styleTag) {
            styleTag.remove();
        }
    }
};

var tooltipHandler = {
    registerMouseDown: function () {
        document.addEventListener('mousedown', function (event) {
            if (event.target && event.target.closest('.walkthrough-toolbar-overlay')) {
                const overlay = document.querySelector('.walkthrough-toolbar-overlay');
                const tooltip = document.querySelector('.walkthrough-tooltip');
                const overlayHighlight = document.querySelector('.walkthrough-highlight');
                if (overlay && !overlay.classList.contains('e-hidden')) {
                    overlay.classList.add('e-hidden');
                    if (tooltip) {
                        tooltip.style.display = 'none';
                    }
                    if (overlayHighlight) {
                        document.querySelectorAll('.walkthrough-highlight').forEach(el => {
                            el.classList.remove('walkthrough-highlight');
                        });
                    }
                }
            }
        });
    }
};

var hideMenuOnResize = () => {
    const menuElement = document.querySelector('.e-menu-vscroll.e-lib.e-vscroll.e-control.e-touch');
    if (menuElement) {
        menuElement.style.display = 'none';
    }
};

var registerResizeHandler = function (dotNetHelper) {
    const handleWindowResize = () => {
        dotNetHelper.invokeMethodAsync('OnWindowResized');
    };

    window.addEventListener('resize', handleWindowResize);

    // Optional: return a cleanup function if needed
    return () => {
        window.removeEventListener('resize', handleWindowResize);
    };
};

var resizeHandler = {
    previousWidth: window.innerWidth,
    previousHeight: window.innerHeight,
    resizeTimeout: null,

    registerResizeCallback: function (dotNetHelper) {
        window.onresize = () => {
            clearTimeout(window.resizeHandler.resizeTimeout);

            window.resizeHandler.resizeTimeout = setTimeout(() => {
                const currentWidth = window.innerWidth;
                const currentHeight = window.innerHeight;

                const resized = currentWidth !== window.resizeHandler.previousWidth ||
                    currentHeight !== window.resizeHandler.previousHeight;

                // Update previous dimensions
                window.resizeHandler.previousWidth = currentWidth;
                window.resizeHandler.previousHeight = currentHeight;

                if (resized) {
                    const overlay = document.querySelector('.walkthrough-toolbar-overlay');
                    const tooltip = document.querySelector('.walkthrough-tooltip');
                    const overlayHighlight = document.querySelector('.walkthrough-highlight');
                    if (overlay && !overlay.classList.contains('e-hidden')) {
                        overlay.classList.add('e-hidden');
                        if (tooltip) {
                            tooltip.style.display = 'none';
                        }
                        if (overlayHighlight) {
                            document.querySelectorAll('.walkthrough-highlight').forEach(el => {
                                el.classList.remove('walkthrough-highlight');
                            });
                        }
                    }
                }
            }, 200); // Debounce delay in milliseconds
        };
    }
};


var walkthroughHelper = {
    calculateTooltipPosition: function (selector, arrowPosition) {
        const element = document.querySelector(selector);
        if (!element) return { top: 0, left: 0 };

        const rect = element.getBoundingClientRect();
        const tooltipWidth = 350;
        const tooltipHeight = 180;
        const padding = 15;
        let top, left;

        // Adjust position based on arrow position
        switch (arrowPosition) {
            case 'top-right':
                top = rect.bottom + padding + window.scrollY;
                left = rect.left + window.scrollX;
                break;
            case 'top-left-center':
                top = rect.bottom + padding + window.scrollY;
                left = rect.left - (tooltipWidth / 4) + window.scrollX;
                break;
            case 'left-center':
                top = rect.top + (rect.height / 2) - (tooltipHeight / 2) + window.scrollY;
                left = rect.right + padding + window.scrollX;
                break;
            case 'right-center':
                top = rect.top + rect.height + window.scrollY;
                left = rect.left + window.scrollX - padding - tooltipWidth;
                break;
            default:
                top = rect.bottom + padding + window.scrollY;
                left = rect.left + window.scrollX;
        }

        // Ensure tooltip stays within viewport
        left = Math.min(Math.max(left, padding), window.innerWidth + window.scrollX - tooltipWidth - padding);
        top = Math.min(Math.max(top, window.scrollY + padding), window.innerHeight + window.scrollY - tooltipHeight);

        return { top, left };
    },


    removeWalkthroughHighlight: () => {
        document.querySelectorAll('.walkthrough-highlight').forEach(el => {
            el.classList.remove('walkthrough-highlight');
        });
    },


    highlightElement: function (selector) {
        // Remove old highlights
        const padding = 15;
        const tooltipWidth = 350;
        document.querySelectorAll('.walkthrough-highlight').forEach(el => {
            el.classList.remove('walkthrough-highlight');
            el.style.zIndex = '';
        });
        const element = document.querySelector(selector);
        const container = document.querySelector('.e-content');
        if (selector == ".orderdate_settings_icon" || selector == "td.e-summarycell[data-cell='Freight']") {
            const containerRect = container.getBoundingClientRect();
            const elementRect = element.getBoundingClientRect();
            let newScrollLeft = container.scrollLeft;
            const elementLeftRelative = elementRect.left - containerRect.left;
            newScrollLeft = (elementLeftRelative / 2) + container.scrollLeft + (selector == "td.e-summarycell[data-cell='Freight']" ? 0 : tooltipWidth);
            if (newScrollLeft !== container.scrollLeft) {
                container.scrollTo({ left: newScrollLeft, behavior: 'auto' });
            }
        } else {
            container.scrollLeft = 0;
            container.scrollTo({ left: container.scrollLeft, behavior: 'auto' });
        }

        // Add new highlight

        if (element) {
            element.classList.add('walkthrough-highlight');
            // Scroll element into view if needed
            if (!this.isInViewport(element)) {
                element.scrollIntoView({ behavior: 'smooth', block: 'center' });
            }
        }
    },
    isInViewport: function (el) {
        const rect = el.getBoundingClientRect();
        return (
            rect.top >= 0 &&
            rect.left >= 0 &&
            rect.bottom <= window.innerHeight &&
            rect.right <= window.innerWidth
        );
    }
};