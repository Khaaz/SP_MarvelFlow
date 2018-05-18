# Evaluation

## Remarques générales

* Vos enum doivent être séparées. Elles sont soumises aux mêmes bonnes pratiques que les classes en .Net : un fichier par enum.

## Objets 2 : Conception et programmation orientées objets (C#, .NET)

### Documentation

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais concevoir un diagramme de classes qui représente mon application. | 6 | 8 | Je ne comprends pas les dépendances que vous avez mises entre Serie/Movie et Video ni entre Comment et Response. Il me faut une justification (dans la description des diagrammes)
| Je sais réaliser un diagramme de paquetages qui illustre bien l'isolation entre les parties de mon application. | 0 | 4 | Pas de diagramme de paquetage.
| Je sais réaliser un diagramme de séquences qui décrit l'un des processus de mon application. | 0 | 2 | Il manque le diagramme de séquence
| Je sais décrire mes trois diagrammes en mettant en valeur et en justifiant les éléments essentiels. | 0 | 6 | Il manque la description.

**Note provisoire** : 06/20

### Code

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je maîtrise les bases de la programmation C# (classes, structures, instances...) | 2 | 2 | OK |  
| Je sais utiliser l'abstraction à bon escient (héritage, interface, polymorphisme). | 1 | 3 | Je vois une classe abstraite (Movie) certainement en cours de développement. Votre diagramme de classes n'est pas totalement implémenté encore. |
| Je sais gérer des collections simples (tableaux, listes, ...) | 1 | 2 | Une liste existe mais n'est pas encore utilisée. |
| Je sais gérer des collections avancées (dictionnaires). | 0 | 2 | Pas de collection avancée pour le moment. |
| Je sais contrôler l'encapsulation au sein de mon application. | 2.5 | 5 | J'attends de voir l'implémentation complète. |
| Je sais tester mon application. | 0 | 4 | Pas de tests. Pensez-y ! |
| Je sais utiliser LINQ. | 0 | 1 | Pas de LinQ |
| Je sais gérer les évènements. | 0 | 1 | Le métier n'émet pas d'évènement. |

**Note provisoire** : 6.5/20

## IHM : Interface Homme-Machine (WAML, WPF)

### Documentation

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais décrire le contexte de mon application pour qu'il soit compréhensible par tout le monde. | 0 | 4 | Absent
| Je sais dessiner des sketchs pour concevoir les fenêtres de mon application. | 0 | 4 | Absent
| Je sais enchaîner mes sketchs au sein d'un storyboard. | 0 | 4 |  Absent
| Je sais concevoir un diagramme de cas d'utilisation qui représente les fonctionnalités de mon application. | 0 | 5 | Absent
| Je sais concevoir une application ergonomique. | 2 | 2 | Je n'ai pas tout vu (il n'y a pas de données) mais pour l'instant, l'application semble être bien conçue.
| Je sais concevoir une application avec une prise en compte de l'accessibilité. | 0 | 1 | En quoi votre application prend-elle en compte l'accessibilité ?

**Note provisoire** : 02/20

### Code

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais choisir mes layouts à bon escient. | 1 | 1 | OK |
| Je sais choisir mes composants à bon escient. | 1 | 1 | OK |
| Je sais créer mon propre composant. | 2 | 2 | OK |
| Je sais personnaliser mon application en utilisant des ressources et des styles. | 2 | 2 | Vous pouvez aller plus loin mais c'est bien |
| Je sais utiliser les DataTemplates (locaux et globaux). | 0 | 2 | Pensez à utiliser des DT une fois que vous aurez implémenter l'affichage des films / heroes |
| Je sais intercepter les évènements de la vue. | 0 | 2 | Les vues ne font pas encore beaucoup de choses |
| Je sais notifier la vue depuis des évènements métier. | 0 | 2 | Le métier n'émet pas d'évènement |
| Je sais gérer le DataBinding sur mon master. | 0 | 1 | Pas de DB encore  |
| Je sais gérer le DataBinding sur mon détail. | 0 | 1 | Pas de DB encore |
| Je sais gérer le DataBinding et les Dependency Property sur mes UserControls. | 0 | 2 | Vous avez des user controls, il suffit de les coder |
| Je sais développer un Master/Detail (navigation, liens entre les deux écrans, ...) | 4 | 4 | c'est encourageant, il vous reste plus qu'à tout connecter |

**Note provisoire** : 10/20

## Projet Tuteuré S2

### Documentation

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais mettre en avant dans mon diagramme de classes la persistance de mon application. | 0 | 2 | Il manque le diagramme
| Je sais mettre en avant dans mon diagramme de classes ma partie personnelle. | 0 | 4 | Il manque le diagramme
| Je sais mettre en avant dans mon diagramme de paquetages la persistance de mon application. | 0 | 4 | Il manque le diagramme
| Je sais réaliser une vidéo de 1 à 3 minutes qui montre la démo de mon application. | 0 | 10 | Il manque la vidéo

**Note provisoire** : 0/20

### Code

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais coder la persitance au sein de mon application. | 1 | 3 | Bon début |
| Je sais coder une fonctionnalité qui m'est personnelle. | 3 | 3 | Je considère que l'utilisation de MVVM est un bon apport personnel - si vous le maitrisez ! |
| Je sais documenter mon code. | 0 | 2 | Peu de documentation pour l'instant |
| Je sais utiliser Git. | 2 | 2 | Oui ! |
| Je sais développer une application qui compile. | 3 | 3 | OK |
| Je sais développer une application fonctionnelle. | 1 | 4 | Erreur d'exécution lors de la désérialisation de votre fichier json. |
| Je sais mettre à disposition un outil pour déployer mon application. | 0 | 3 | Pas d'installer |

**Note provisoire** : 08/20
