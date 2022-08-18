function formata(campo, mask, evt) {
   var strCheck = '0123456789,/-';   
   var tecla;
   var key
   
   if(evt.which)  
   {  
      key = evt.which;
   }  
   else
   {
      if(evt.keyCode) // Netscape/Firefox/Opera  
      {  
         key = evt.keyCode;  
       }  
   } 
   
   if(key==8)return true;
   if(key==9)return true;
   if(key==13)return true;
   if(key==37)return true;
   if(key==39)return true;
   if(key==47)return true;
   if(key==127)return true;

   string = campo.value;  
   i = String.length;
   tecla = String.fromCharCode(key);

   if (i < mask.length)
   {
      if (mask.charAt(i) == '?')
      {
         return ( strCheck.indexOf(tecla) >= 0 );
      }
      else
      {
         if (mask.charAt(i) == '!') 
         {  
            return true;  
         }
         for (c = i; c < mask.length; c++)
         {
            if (mask.charAt(c) != '?' && mask.charAt(c) != '!')
            campo.value = campo.value + mask.charAt(c);
         else
            if (mask.charAt(c) == '!')
            {
               return true;
            }
            else
            {
               return ( strCheck.indexOf(tecla) >= 0 );
            }
         }
      }
   }
   else 
   {
      return false;
   }
}

function formatarNumerico(fld, milSep, decSep, e, nrCasas) {   
    var BCK=8,TAB=9,key,tecla;CheckTAB=true;
    var sep = 0;   
    var key = '';   
    var i = j = 0;   
    var len = len2 = 0;   
    var strCheck = '0123456789';   
    var aux = aux2 = '';   
    
    if(event.which)tecla=event.which;
    else tecla=event.keyCode;
    
    key=String.fromCharCode(tecla);
    
    if(tecla==BCK)return true;
    if(tecla==TAB)return true;
    if(tecla==13)return true;
    
    if (strCheck.indexOf(key) == -1) return false;  // Chave não válida  
    len = fld.value.length;   
    
    for(i = 0; i < len; i++)  if ((fld.value.charAt(i) != '0') && (fld.value.charAt(i) != decSep)) break;   
    
    aux = '';   
    for(; i < len; i++) if (strCheck.indexOf(fld.value.charAt(i))!=-1) aux += fld.value.charAt(i);   
    
    aux += key;   
    len = aux.length;   
    if (len == 0) fld.value = '';   
    
    if (nrCasas == 2) {
        if (len == 1) fld.value = '0'+ decSep + '0' + aux;   
        if (len == 2) fld.value = '0'+ decSep + aux;   
    } else {
        if (nrCasas == 3) {
            if (len == 1) fld.value = '0'+ decSep + '00' + aux;   
            if (len == 2) fld.value = '0'+ decSep + '0' + aux;   
            if (len == 3) fld.value = '0'+ decSep + aux;   
        } else {
            if (len == 1) fld.value = '0'+ decSep + '000' + aux;   
            if (len == 2) fld.value = '0'+ decSep + '00' + aux;   
            if (len == 3) fld.value = '0'+ decSep + '0' + aux;   
            if (len == 4) fld.value = '0'+ decSep + aux;   
        }
    }
    if (len > nrCasas) {   
        aux2 = '';   
        for (j = 0, i = len - (nrCasas + 1); i >= 0; i--) {   
            if (j == 3) {   
                aux2 += milSep;   
                j = 0;   
            }   
            aux2 += aux.charAt(i);   
            j++;   
        }   
        fld.value = '';   
        len2 = aux2.length;   
        for (i = len2 - 1; i >= 0; i--) fld.value += aux2.charAt(i);   
        
        fld.value += decSep + aux.substr(len - nrCasas, len);   
    }   
    return false;   
}   

function selecionaCampo(fld) {
  fld.select();
}

function ShowEditModal(janela,modalname,framename) {
        var frame = $get(framename);
        frame.src = janela ;
        $find(modalname).show();
}

function EditCancelScript(framename) {
        var frame = $get(framename);
        frame.src = "WFCarregando.aspx";
}

function EditOkayScript(framename) {
        EditCancelScript(framename);
}

function formatacampo(src, mask) 

{

var i = src.value.length;

      var saida = mask.substring(0,1);

      var texto = mask.substring(i)

      if (texto.substring(0,1) != saida) 

      {

         src.value += texto.substring(0,1);

      }

 }

 function formataCampoData(src) {
     var v;

     v = src.value;
     v = v.replace(/\D/g, "");
     v = v.replace(/(\d{2})(\d)/, "$1/$2");
     v = v.replace(/(\d{2})(\d)/, "$1/$2");
     v = v.replace(/(\d{2})(\d{2})$/, "$1$2");

     src.value = v;
 }

 /* Máscaras ER */
 function mascara(o, f) {
     v_obj = o
     v_fun = f
     setTimeout("execmascara()", 1)
 }
 function execmascara() {
     v_obj.value = v_fun(v_obj.value)
 }
 function mvalor(v) {
     v = v.replace(/\D/g, ""); //Remove tudo o que não é dígito  
     v = v.replace(/(\d)(\d{8})$/, "$1.$2"); //coloca o ponto dos milhões  
     v = v.replace(/(\d)(\d{5})$/, "$1.$2"); //coloca o ponto dos milhares  
     v = v.replace(/(\d)(\d{2})$/, "$1,$2"); //coloca a virgula antes dos 2 últimos dígitos  
     return v;
 }
 function mvalor4dec(v) {
     v = v.replace(/\D/g, ""); //Remove tudo o que não é dígito  
     v = v.replace(/(\d)(\d{10})$/, "$1.$2"); //coloca o ponto dos milhões  
     v = v.replace(/(\d)(\d{7})$/, "$1.$2"); //coloca o ponto dos milhares  
     v = v.replace(/(\d)(\d{4})$/, "$1,$2"); //coloca a virgula antes dos 4 últimos dígitos  
     return v;
 }
 function mcep(v) {
     v = v.replace(/\D/g, "")                    //Remove tudo o que não é dígito  
     v = v.replace(/^(\d{5})(\d)/, "$1-$2")         //Esse é tão fácil que não merece explicações  
     return v
 }
 
 function mtel(v) {
     v = v.replace(/\D/g, "");             //Remove tudo o que não é dígito  
     v = v.replace(/^(\d{2})(\d)/g, "($1) $2"); //Coloca parênteses em volta dos dois primeiros dígitos  
     v = v.replace(/(\d)(\d{4})$/, "$1-$2");    //Coloca hífen entre o quarto e o quinto dígitos  
     return v;
 }  
 function cnpj(v) {
     v = v.replace(/\D/g, "")                           //Remove tudo o que não é dígito  
     v = v.replace(/^(\d{2})(\d)/, "$1.$2")             //Coloca ponto entre o segundo e o terceiro dígitos  
     v = v.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3") //Coloca ponto entre o quinto e o sexto dígitos  
     v = v.replace(/\.(\d{3})(\d)/, ".$1/$2")           //Coloca uma barra entre o oitavo e o nono dígitos  
     v = v.replace(/(\d{4})(\d)/, "$1-$2")              //Coloca um hífen depois do bloco de quatro dígitos  
     return v
 }
 function mcpf(v) {
     v = v.replace(/\D/g, "")                    //Remove tudo o que não é dígito  
     v = v.replace(/(\d{3})(\d)/, "$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos  
     v = v.replace(/(\d{3})(\d)/, "$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos  
     //de novo (para o segundo bloco de números)  
     v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2") //Coloca um hífen entre o terceiro e o quarto dígitos  
     return v
 }
 function mdata(v) {
     v = v.replace(/\D/g, "");                    //Remove tudo o que não é dígito  
     v = v.replace(/(\d{2})(\d)/, "$1/$2");
     v = v.replace(/(\d{2})(\d)/, "$1/$2");

     v = v.replace(/(\d{2})(\d{2})$/, "$1$2");
     return v;
 }
 function mtempo(v) {
     v = v.replace(/\D/g, "");                    //Remove tudo o que não é dígito  
     v = v.replace(/(\d{1})(\d{2})(\d{2})/, "$1:$2.$3");
     return v;
 }
 function mhora(v) {
     v = v.replace(/\D/g, "");                    //Remove tudo o que não é dígito  
     v = v.replace(/(\d{2})(\d)/, "$1h$2");
     return v;
 }
 function mrg(v) {
     v = v.replace(/\D/g, "");                                      //Remove tudo o que não é dígito  
     v = v.replace(/(\d)(\d{7})$/, "$1.$2");    //Coloca o . antes dos últimos 3 dígitos, e antes do verificador  
     v = v.replace(/(\d)(\d{4})$/, "$1.$2");    //Coloca o . antes dos últimos 3 dígitos, e antes do verificador  
     v = v.replace(/(\d)(\d)$/, "$1-$2");               //Coloca o - antes do último dígito  
     return v;
 }
 function mnum(v) {
     v = v.replace(/\D/g, "");                                      //Remove tudo o que não é dígito  
     return v;
 }  