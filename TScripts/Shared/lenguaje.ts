// Importar i18next y el detector de idioma
declare const i18next: any;
declare const i18nextBrowserLanguageDetector: any;

// Configurar i18next
i18next
    .use(i18nextBrowserLanguageDetector)  // Usar el detector de idioma
    .init({
        resources: {
            en: {
                translation: {
                    "welcome": "Welcome to our website",
                    "description": "This is a sample description"
                }
            },
            es: {
                translation: {
                    "welcome": "Bienvenido a nuestro sitio web",
                    "description": "Esta es una descripción de muestra"
                }
            }
        },
        fallbackLng: 'en',  // Idioma por defecto
        interpolation: {
            escapeValue: false
        }
    }, (err: any, t: any) => {
        if (err) return console.error('i18next initialization error:', err);
        // Inicialización completa
        updateContent();
    });

// Función para actualizar el contenido de la página según el idioma
function updateContent() {
    document.getElementById('welcome')!.innerText = i18next.t('welcome');
    document.getElementById('description')!.innerText = i18next.t('description');
}

// Cambiar el idioma de la página
function changeLanguage(lng: string) {
    i18next.changeLanguage(lng, (err: any) => {
        if (err) return console.error('Language change error:', err);
        updateContent();
    });
}

// Escuchar eventos de cambio de idioma en los botones
document.getElementById('en-btn')!.addEventListener('click', () => changeLanguage('en'));
document.getElementById('es-btn')!.addEventListener('click', () => changeLanguage('es'));

// Inicializar el contenido de la página
updateContent();
