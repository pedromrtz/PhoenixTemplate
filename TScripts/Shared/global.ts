// Objective: Global functions to be used in the project.

// The capitalizarPrimeraLetra function is defined to capitalize the first letter of a string
export function capitalizarPrimeraLetra(texto: string) :string {
    return texto.charAt(0).toUpperCase() + texto.slice(1).toLowerCase();
}


// The AskToLlama function is defined to send a request to the Llama API
export async function AskToLlama(prompt: string, role_sys: string) {
    const url = 'http://localhost:1234/v1/chat/completions';
    const apiKey = 'lm-studio';
    const model = 'model-identifier';

    const requestBody = {
        model: model,
        messages: [
            { role: 'system', content: role_sys },
            { role: 'user', content: prompt }
        ],
        temperature: 0.7
    };

    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${apiKey}`
        },
        body: JSON.stringify(requestBody)
    });

    if (!response.ok) {
        return new Error(`Error: ${response.statusText}`);
    }

    const data = await response.json();
    
    if (typeof data.choices[0].message.content === 'string') {
        data.choices[0].message.content = data.choices[0].message.content.replace(/\n/g, '');
    }

    return data.choices[0].message;
}
