using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Configurations
{
    public class BookDBInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            if (!context.Books.Any())
            {
                IList<Book> defaultStandards = new List<Book>();

                defaultStandards.Add(new Book()
                {
                    Title = "The Picture of Dorian Gray",
                    Price = "50",
                    ImageName = "book1.jpg",
                    Summary = "Horror hides behind an attractive face in The Picture of Dorian Gray, Oscar Wilde's tale of a notorious Victorian libertine and his life of evil excesses." +
                        " Though Dorian's hedonistic indulgences leave no blemish on his ageless features, the painted portrait imbued with his soul proves a living catalogue of corruption, revealing in its every new line and lesion the manifold sins he has committed. " +
                        "Desperate to hide the physical evidence of his unregenerate spirit, Dorian will stop at nothing—not even murder—to keep his picture's existence a secret."
                });

                defaultStandards.Add(new Book()
                {
                    Title = "Pride and Prejudice",
                    Price = "45",
                    ImageName = "book2.jpg",
                    Summary = "\"It is a truth universally acknowledged, that a single man in possession of a good fortune, must be in want of a wife.\" So begins Pride and Prejudice, Jane Austen's classic novel of manners and mores in early-nineteenth-century England." +
                        " As the Bennets prepare their five grown daughters to enter into society, each shows personality traits that illuminate their future prospects as wives. Jane, the oldest, is the most demure and traditional, and Lydia, the youngest, the most headstrong and impulsive. " +
                        "Attention centers on haughty second-born Elizabeth, and her blossoming relationship with the dashing but aloof Fitzwilliam Darcy. Adversaries at first in the endless rounds of balls, parties, and social gatherings, they soon develop a grudging respect for one another that blossoms into romance when each comes to appreciate the tender feelings that course beneath the veneer of their propriety and reserve."
                });

                defaultStandards.Add(new Book()
                {
                    Title = "Little Women and Other Novels",
                    Price = "30",
                    ImageName = "book3.jpg",
                    Summary = "This beautiful collectible edition presents three novels from one of the most beloved American authors: Louisa May Alcott. It includes her most famous and cherished classic, Little Women, about the lives of four sisters in Civil War–era America, as well as its sequels, Little Men and Jo’s Boys."
                });

                context.Books.AddRange(defaultStandards);

                base.Seed(context);
            }
        }
    }
}