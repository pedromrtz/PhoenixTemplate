import * as global from './global.js';

window.onload = async () => {
    
    const initlang: string = localStorage.getItem('lang') || 'es';
    await traducirPagina(initlang);
    function traducirPagina(idioma) {
        const elementosATraducir = document.querySelectorAll('.traducir');

        elementosATraducir.forEach(elemento => {
            const textoOriginal = elemento.textContent;
            const url = `/proxy-translate?q=${encodeURIComponent(textoOriginal)}&tl=${idioma}`;

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    let textoTraducido = global.capitalizarPrimeraLetra(data[0][0][0]); 
                    elemento.textContent = textoTraducido;
                })
                .catch(error => {
                    console.error('Error al traducir:', error);
                });
        });
    }


    const lang_es = document.getElementById('lang_es') as HTMLButtonElement;
    const lang_en = document.getElementById('lang_en') as HTMLButtonElement;
    const lang_pt = document.getElementById('lang_pt') as HTMLButtonElement;
    const lang_ch = document.getElementById('lang_ch') as HTMLButtonElement;

    if (lang_es != null && lang_en != null && lang_pt != null && lang_ch != null) {

        lang_es.onclick = async () => {
            await traducirPagina('es')
            localStorage.setItem('lang', 'es');
        }

        lang_en.onclick = async () => {
            await traducirPagina('en')
            localStorage.setItem('lang', 'en');
        }

        lang_pt.onclick = async () => {
            await traducirPagina('pt')
            localStorage.setItem('lang', 'pt');
        }

        lang_ch.onclick = async () => {
            await traducirPagina('zh')
            localStorage.setItem('lang', 'zh');
        }

    }

    


}