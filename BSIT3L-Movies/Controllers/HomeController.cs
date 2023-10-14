using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BSIT3L_Movies.Models;
using System.Collections.Generic;

namespace BSIT3L_Movies.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly List<MovieViewModel> _movies;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _movies = new List<MovieViewModel>
         {
               new MovieViewModel { Id = 1, Name = "Avengers Infinity War", Rating = "10", ReleaseYear = 2018, Genre = "Action/Superhero/Sci-Fi", Photourl = "/Images/infinitywar.jpg", url = "https://youtu.be/QwievZ1Tx-8" ,Description = "A new threat has emerged from the darkness: Thanos Since the Avengers and their allies have continued to defend the planet from dangers overly large to handle. A despot of infamy, his aim is to collect all six Infinity Stonesartifacts of unimaginable power, and utilize them to inflict his jagged will. Everything the Avengers have fought for has led up to the moment - the fate of existence and Earth has never been more uncertain."},
                new MovieViewModel { Id = 2, Name = "Captain America The Winter Soldier", Rating = "9", ReleaseYear = 2014, Genre = "Action/Sci-Fi", Photourl = "/Images/wintersoldier.jpg",url = "https://youtu.be/7SlILk2WMTI", Description = "After the cataclysmic events from New York with The Avengers, Steve Rogers, aka Captain America is living quietly in Washington, D.C. and trying to adjust to the world. However, if a S.H.I.E.L.D. colleague comes under attack, Steve becomes embroiled in a web of intrigue that threatens to put the world at risk. Joining forces with the Black Widow, Captain America fights to expose that the ever-widening conspiracy whilst fighting off professional assassins delivered to silence him. After the complete range of this plot is shown, Captain America and the Black Widow enlist the aid of a brand new ally, the Falcon. But they soon find themselves facing an enemy--that the Winter Soldier."},
                new MovieViewModel { Id = 3, Name = "Hello World", Rating = "8", ReleaseYear = 2019, Genre = "Sci-Fi/Romance", Photourl = "/Images/helloworld.jpg",url = "https://youtu.be/shoWFRnNoWw", Description = "A man travels in time from the year 2027 to relive his school years and to correct a bad decision."},
                new MovieViewModel { Id = 4, Name = "Jujutsu Kaisen 0", Rating = "9", ReleaseYear = 2021, Genre = "Fantasy/Action", Photourl = "/Images/jjk0.jpg",url = "https://youtu.be/3CntN98B84g", Description = "Yuta Okkotsu is a nervous high school student with a serious problem: his childhood friend Rika has turned into a curse and will not leave him alone. Satoru Gojo, a teacher at Jujutsu High, a school where aspiring exorcists learn how to combat curses, notices Rika's plight because he is not your average curse. Yuta is persuaded to enroll by Gojo, but will he be able to learn enough in time to face the curse that haunts him?"},
                new MovieViewModel { Id = 5, Name = "Guardians of the Galaxy Vol. 3", Rating = "9", ReleaseYear = 2023, Genre = "Sci-Fi/Action", Photourl = "/Images/gotg3.jpg",url = "https://youtu.be/u3V5KDHRQvk", Description = "Peter Quill, still reeling from the loss of Gamora, must rally his team around him to defend the universe along with protecting one of their own. A mission that, if not completed successfully, could quite possibly lead to the end of the Guardians as we know them."},
                new MovieViewModel { Id = 6, Name = "Black Panther", Rating = "8", ReleaseYear = 2018, Genre = "Action/Sci-Fi", Photourl = "/Images/blackpanther.jpg",url = "https://youtu.be/xjDjIWPwcPU", Description = "King T'Challa returns into the reclusive advanced nation of Wakanda to serve as the new leader of his country. However, T'Challa soon discovers that he is contested to your throne with factions within his or her own country in addition to without. Using powers allowed for Wakandan kings, T'Challa assumes the Black Panther mantel to join with girlfriend Nakia, the queen mother, '' his princess-kid sister, members of their Dora Milaje (the Wakandan'special forces') and an American secret agent, to prevent Wakanda out of being dragged into a world war."},
                new MovieViewModel { Id = 7, Name = "Avengers Endgame", Rating = "10", ReleaseYear = 2019, Genre = "Action/Sci-Fi", Photourl = "/Images/endgame.jpg",url = "https://youtu.be/TcMBFSGVi1c", Description = "The universe Remains due to Their Mad Titan, Thanos' efforts. With the aid of allies that are remaining, the Avengers must build to undo Thanos' actions and restore order to the world once and for all."},
                new MovieViewModel { Id = 8, Name = "Heneral Luna", Rating = "8", ReleaseYear = 2015, Genre = "Action/History", Photourl = "/Images/heneralluna.jpg",url = "https://youtu.be/I_T1ykhy3Fg", Description = "Could turn the tide of struggle from the Philippine-American war. But little does he know he faces a threat to this nation's revolution against the invading Americans." },
                new MovieViewModel { Id = 9, Name = "Iron Man", Rating = "9", ReleaseYear = 2008, Genre = "Action/Sci-Fi", Photourl = "/Images/ironman.jpg",url = "https://youtu.be/8ugaeA-nMTc", Description = "A billionaire industrialist and genius inventor, Tony Stark, is conducting weapons tests overseas, but terrorists kidnap him to force him to build a devastating weapon. Instead, he builds an armored suit and upends his captors. Returning to America, Stark refines the suit and uses it to combat crime and terrorism." },
                new MovieViewModel { Id = 10, Name = "Eternals", Rating = "7", ReleaseYear = 2021, Genre = "Action/Sci-Fi", Photourl = "/Images/eternals.jpg",url = "https://youtu.be/x_me3xsvDgk", Description = "The Eternals are a group of ancient aliens who have been surviving Earth in secret for countless years. When an unanticipated disaster compels them out of the shadows, they are required to reunite against mankind's most ancient opponent, the Deviants." },
                new MovieViewModel { Id = 11, Name = "Transformers", Rating = "8", ReleaseYear = 2007, Genre = "Action/Sci-Fi", Photourl = "/Images/transformers.jpg",url = "https://youtu.be/v8ItGrI-Ou0", Description = "Young teenager, Sam Witwicky becomes involved from the struggle of transforming robots, between two extraterrestrial factions -- both the heroic Autobots and the evil Decepticons. Sam holds the hint and also the Decepticons will stop at nothing to regain it." },
                new MovieViewModel { Id = 12, Name = "Suicide Squad", Rating = "7", ReleaseYear = 2016, Genre = "Action/Adventure", Photourl = "/Images/suicidesquad.jpg",url = "https://youtu.be/CmRih_VtVAs", Description = "Figuring they're all expendable, a U.S. intelligence officer decides to assemble a team of dangerous, incarcerated supervillains for a top-secret mission. Now armed with government weapons, Deadshot, Harley Quinn, Captain Boomerang, Killer Croc and other despicable inmates must learn to work together. Dubbed Task Force X, the criminals unite to battle a mysterious and powerful entity, while the diabolical Joker launches an evil agenda of his own." },
                new MovieViewModel { Id = 13, Name = "Venom", Rating = "8", ReleaseYear = 2018, Genre = "Action/Sci-Fi", Photourl = "/Images/venom.jpg",url = "https://youtu.be/u9Mv98Gr5pY", Description = "Journalist Eddie Brock is trying to take down Carlton Drake, the notorious and brilliant founder of the Life Foundation. While investigating one of Drake's experiments, Eddie's body merges with the alien Venom -- leaving him with superhuman strength and power. Twisted, dark and fueled by rage, Venom tries to control the new and dangerous abilities that Eddie finds so intoxicating." },
                new MovieViewModel { Id = 14, Name = "Doctor Strange in the Multiverse of Madness", Rating = "9", ReleaseYear = 2022, Genre = "Action/Adventure", Photourl = "/Images/strange.jpg",url = "https://youtu.be/aWzlQ2N6qqg", Description = "Doctor Strange teams up with a mysterious teenage girl from his dreams who can travel across multiverses, to battle multiple threats, including other-universe versions of himself, which threaten to wipe out millions across the multiverse." },
                new MovieViewModel { Id = 15, Name = "Us", Rating = "7", ReleaseYear = 2019, Genre = "Horror/Thriller", Photourl = "/Images/us.jpg",url = "https://youtu.be/hNCmb-4oXJA", Description = "Accompanied by her husband, son and daughter, Adelaide Wilson returns to the beachfront home where she grew up as a child. Haunted by a traumatic experience from the past, Adelaide grows increasingly concerned that something bad is going to happen. Her worst fears soon become a reality when four masked strangers descend upon the house, forcing the Wilsons into a fight for survival. When the masks come off, the family is horrified to learn that each attacker takes the appearance of one of them." },
            };
    }

    public IActionResult Index()
    {
        return View(_movies);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

