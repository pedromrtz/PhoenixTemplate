// Objective: Manage the language of the page.

//import all the functions from the global.js file
import * as global from './global.js';

document.addEventListener("DOMContentLoaded", () => {
    
    //The TranslationResponse interface is defined to manage the response of the translation
    interface TranslationResponse {
        original: string;
        translated: string;
    }
    //The role_sys variable is defined to store the role of the system in the chat prompt
    const role_sys: string = `Eres un traductor. A continuacion, te proporcionare un JSON cuyas claves indican el codigo de cada idioma: { "en" : "english", "es" : "spanish", "pt" : "portuguese", "zh" : "chinese" } Ahora te compartire un ejemplo de JSON cuya clave "content" contendra un texto, y la clave "target" indicara el idioma al que debe ser traducido el texto: { "content" : "Hola, por favor traduce este mensaje", "target" : "en" } Por favor, responde unicamente con un JSON en texto plano (plain text) que contenga las claves "original" y "translated". La clave "original" debe contener el mismo texto proporcionado en "content", y la clave "translated" debe contener el texto traducido al idioma especificado en "target". Ejemplo de respuesta esperada: { "original" : "Hola, por favor traduce este mensaje", "translated" : "Hello, please translate this message" } La respuesta debe ser igualmente en texto plano (plain text), sin incluir notas, comentarios, ni informacion adicional; solo responde con el objeto JSON solicitado. A continuacion te proporcionare el JSON con el content que deberas traducir:`;

    //The initlang variable is defined to store the language of the page that is stored in the local storage
    const initlang: string = localStorage.getItem('lang') || 'en';
    // If the language is not Spanish, the page is translated
    if (initlang != 'es') {
        traducirPagina(initlang);
    }

    // The traducirPagina function is defined to translate the page
    async function traducirPagina(idioma: string) {
        
        // The elementosATraducir variable is defined to store all the elements that have the class "traducir"
        const elementosATraducir: NodeListOf<HTMLElement> = document.querySelectorAll('.traducir');
        const elementosArray = Array.from(elementosATraducir);
        
        // The for loop is defined to iterate over the elements to be translated
        for (const elemento of elementosArray) {
            // The textoOriginal variable is defined to store the text content of the element
            const textoOriginal = elemento.textContent || '';
            // If the text content is empty, the loop continues
            if (textoOriginal == '') {
                continue;
            }
            // The chatPrompt variable is defined to store the JSON with the text content and the target language
            const chatPrompt = `{"content" : "${textoOriginal}","target" : "${idioma}"}`;
            
            try {
                // The message variable is defined to store the response of the translation
                const message = await global.AskToLlama(chatPrompt, role_sys);
                const chatResponse: TranslationResponse = JSON.parse(message.content);
                // The text content of the element is replaced by the translated text
                elemento.textContent = chatResponse.translated;
                continue;
            } catch (error) {
                console.error('Error:', error);
            }
            // if the translation fails the first time the loop breaks
            break;
        }
    }
    
    // The lang_es variable is defined to store the button with the id "lang_es"
    const lang_es = document.getElementById('lang_es') as HTMLButtonElement;
    const lang_en = document.getElementById('lang_en') as HTMLButtonElement;
    const lang_pt = document.getElementById('lang_pt') as HTMLButtonElement;

    // If the language buttons exist, the event listeners are added to change the language
    if (lang_es && lang_en && lang_pt) {
        lang_es.onclick = () => changeLanguage('es');
        lang_en.onclick = () => changeLanguage('en');
        lang_pt.onclick = () => changeLanguage('pt');
    }

    // The changeLanguage function is defined to change the language of the page
    function changeLanguage(lang: string) {
        localStorage.setItem('lang', lang);
        window.location.reload();
    }

});

