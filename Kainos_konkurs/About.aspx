<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Kainos_konkurs.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Konkurs o staż w Kainos Software Poland.</h2>
    
    <p><strong>Autor:</strong> <em>Marcin Formela, formela91@gmail.com.</em></p>
    <br />
    <br />
    <h4>Opis konkursu.</h4>
    <p> Zadanie polegało na stworzeniu aplikacji webowej, która pobierze dane dotyczące filmów z bazy PostgreSQL zahostowanej na heroku oraz zwizualizowaniu ich wg. wymagań opisanych poniżej.
        Całość należało zahostować w chmurze (np. Heroku, AppHarbor). Kod powininen być umieszczony w repozytorium git'a (github / bitbucket). Wybór technologii jest dowolny. </p>
    <br /><h4>Aplikacja powinna zawierać strony:</h4>
    <ul>
    <li> '/' - ta strona zawiera tabele, w której widnieje ranking 20 filmów. Ranking jest tworzony przy użyciu sortowania: średnia ocen filmu malejąco oraz data ukazania się filmu rosnąco.
        Tabela powinna zawierać 3 kolumny: z tytułami filmu, ze średnią oceną filmu oraz kolumne z linkami do szczegółowego opisu filmu (Szczegóły w ostatnim podpunkcie).</li>
        <br />
    <li> “/topGenre” - ta strona zawiera diagram kołowy, na którym są zaprezentowane procentowo sumy filmów z danych kategorii.</li>
    <br />
    <li> “/search” - ta strona zawiera formularz, w którym zaimplementowane jest szukanie wyników z bazy danych na podstawie dwóch parametrów, gdzie pierwszy parametr określa gatunki filmu,
        drugi określa minimalną wartość średniej ocen szukanego filmu (tzn. szukamy filmów z oceną większą niż np. 7.5).</li>
    <br />
    <li> “/movie/:id” - parametr :id to id filmu z bazy danych. Ta strona wyświetla szczegóły na temat danego filmu, w tym:</li>
       <ul><li>Tytuł filmu</li>
           <li>Średnia ocena użytkowników</li>
           <li>Gatunki jakie reprezentuje dany film</li>
           <li>Opis filmu, który zostanie pobrany przy pomoc imdb api (http://www.omdbapi.com/)</li>
           </ul> 
    <br />
    <li>W razie problemów z ilością połączeń do bazy, można zahostować własną.</li>
        </ul>
</asp:Content>