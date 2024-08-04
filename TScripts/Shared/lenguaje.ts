window.onload = function () {


    const initlang: string = localStorage.getItem('lang') || 'es';
    const elements = document.querySelectorAll('[langId]');

    async function loadJson(): Promise<any> {
        const response = await fetch(`/translation/${initlang}/translation.json`);
        if (!response.ok) {
            throw new Error('No se pudo cargar el archivo JSON.');
        }
        return await response.json();
    }

    loadJson().then(data => {
        const translationData = data;
        //console.log(translationData);

        elements.forEach(element => {
            const key = element.getAttribute('langId');
            if (key) {
                element.innerHTML = translationData[key];
            }
        });

        // Puedes utilizar translationData aquí
    }).catch(error => {
        console.error('Error al cargar el archivo JSON:', error);
    });

    const lang_es = document.getElementById('lang_es') as HTMLButtonElement;
    const lang_en = document.getElementById('lang_en') as HTMLButtonElement;
    const lang_br = document.getElementById('lang_br') as HTMLButtonElement;

    lang_es.onclick = () => {
        localStorage.setItem('lang', 'es');
        location.reload();
    }

    lang_en.onclick = () => {
        localStorage.setItem('lang', 'en');
        location.reload();
    }

    lang_br.onclick = () => {
        localStorage.setItem('lang', 'br');
        location.reload();
    }

}