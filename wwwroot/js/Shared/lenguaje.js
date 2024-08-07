var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
import * as global from './global.js';
document.addEventListener("DOMContentLoaded", function () {
    var role_sys = "Eres un traductor. A continuaci\u00F3n, te proporcionar\u00E9 un JSON cuyas claves indican el c\u00F3digo de cada idioma: { \"en\" : \"english\", \"es\" : \"spanish\", \"pt\" : \"portuguese\", \"zh\" : \"chinese\" } Ahora te compartir\u00E9 un ejemplo de JSON cuya clave \"content\" contendr\u00E1 un texto, y la clave \"target\" indicar\u00E1 el idioma al que debe ser traducido el texto: { \"content\" : \"Hola, por favor traduce este mensaje\", \"target\" : \"en\" } Por favor, responde \u00FAnicamente con un JSON en texto plano (plain text) que contenga las claves \"original\" y \"translated\". La clave \"original\" debe contener el mismo texto proporcionado en \"content\", y la clave \"translated\" debe contener el texto traducido al idioma especificado en \"target\". Ejemplo de respuesta esperada: { \"original\" : \"Hola, por favor traduce este mensaje\", \"translated\" : \"Hello, please translate this message\" } La respuesta debe ser igualmente en texto plano (plain text), sin incluir notas, comentarios, ni informaci\u00F3n adicional; solo responde con el objeto JSON solicitado. A continuaci\u00F3n te proporcionar\u00E9 el JSON con el content que deber\u00E1s traducir:";
    window.onload = function () { return __awaiter(void 0, void 0, void 0, function () {
        function traducirPagina(idioma) {
            return __awaiter(this, void 0, void 0, function () {
                var elementosATraducir, elementosArray, _i, elementosArray_1, elemento, textoOriginal, chatPrompt, message, chatResponse, error_1;
                return __generator(this, function (_a) {
                    switch (_a.label) {
                        case 0:
                            elementosATraducir = document.querySelectorAll('.traducir');
                            elementosArray = Array.from(elementosATraducir);
                            _i = 0, elementosArray_1 = elementosArray;
                            _a.label = 1;
                        case 1:
                            if (!(_i < elementosArray_1.length)) return [3 /*break*/, 7];
                            elemento = elementosArray_1[_i];
                            textoOriginal = elemento.textContent || '';
                            chatPrompt = "\n            {\n            \"content\" : \"".concat(textoOriginal, "\",\n            \"target\" : \"").concat(idioma, "\"\n            }");
                            _a.label = 2;
                        case 2:
                            _a.trys.push([2, 4, , 5]);
                            return [4 /*yield*/, global.AskToLlama(chatPrompt, role_sys)];
                        case 3:
                            message = _a.sent();
                            chatResponse = JSON.parse(message.content);
                            elemento.textContent = chatResponse.translated;
                            return [3 /*break*/, 6];
                        case 4:
                            error_1 = _a.sent();
                            console.error('Error:', error_1);
                            return [3 /*break*/, 5];
                        case 5: return [3 /*break*/, 7];
                        case 6:
                            _i++;
                            return [3 /*break*/, 1];
                        case 7: return [2 /*return*/];
                    }
                });
            });
        }
        function changeLanguage(lang) {
            localStorage.setItem('lang', lang);
            window.location.reload();
        }
        var initlang, lang_es, lang_en, lang_pt;
        return __generator(this, function (_a) {
            initlang = localStorage.getItem('lang') || 'en';
            if (initlang != 'es') {
                traducirPagina(initlang);
            }
            lang_es = document.getElementById('lang_es');
            lang_en = document.getElementById('lang_en');
            lang_pt = document.getElementById('lang_pt');
            if (lang_es && lang_en && lang_pt) {
                lang_es.onclick = function () { return changeLanguage('es'); };
                lang_en.onclick = function () { return changeLanguage('en'); };
                lang_pt.onclick = function () { return changeLanguage('pt'); };
            }
            return [2 /*return*/];
        });
    }); };
});
//# sourceMappingURL=lenguaje.js.map